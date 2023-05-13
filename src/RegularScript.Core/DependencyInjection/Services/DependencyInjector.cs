﻿using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using RegularScript.Core.Common.Exceptions;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Models;
using RegularScript.Core.DependencyInjection.Exceptions;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Models;
using RegularScript.Core.Expressions.Extensions;

namespace RegularScript.Core.DependencyInjection.Services;

public class DependencyInjector : IDependencyInjector
{
    private readonly DependencyInjectorFields fields;

    public DependencyInjector(
        IReadOnlyDictionary<TypeInformation, InjectorItem> injectors,
        IReadOnlyDictionary<AutoInjectMemberIdentifier, InjectorItem> autoInjects,
        IReadOnlyDictionary<ReservedCtorParameterIdentifier, InjectorItem> reservedCtorParameters
    )
    {
        Check(injectors);
        fields = new(injectors, autoInjects, reservedCtorParameters);
    }

    public ReadOnlyMemory<TypeInformation> Inputs => fields.Inputs;
    public ReadOnlyMemory<TypeInformation> Outputs => fields.Outputs;

    public object Resolve(TypeInformation type)
    {
        if (!fields.Injectors.TryGetValue(type, value: out var injectorItem))
        {
            throw new TypeNotRegisterException(type.Type);
        }

        BuildExpression(type, injectorItem, result: out var expression);
        var func = BuildFunc(expression.ThrowIfNull());
        var value = func.Invoke();

        return value;
    }

    public object? Invoke(Delegate del, DictionarySpan<TypeInformation, object> arguments)
    {
        var parameterTypes = del.GetParameterTypes();
        var args = new object[parameterTypes.Length];

        for (var index = 0; index < args.Length; index++)
        {
            if (arguments.TryGetValue(key: parameterTypes[index], value: out var value))
            {
                args[index] = value;
            }
            else
            {
                args[index] = Resolve(type: parameterTypes[index]);
            }
        }

        return del.DynamicInvoke(args);
    }

    public DependencyStatus GetStatus(TypeInformation type)
    {
        if (!fields.Injectors.TryGetValue(type, value: out var injectorItem))
        {
            throw new TypeNotRegisterException(type.Type);
        }

        BuildExpression(type, injectorItem, result: out var expression);

        return new(type, expression.ThrowIfNull());
    }

    private bool BuildExpression(
        TypeInformation type,
        InjectorItem injectorItem,
        [MaybeNullWhen(false)] out Expression result
    )
    {
        switch (injectorItem.Type)
        {
            case InjectorItemType.Singleton:
            {
                if (fields.CacheSingleton.TryGetValue(type, out result))
                {
                    return true;
                }

                if (UpdateParameters(injectorItem.Expression, out result))
                {
                    var constant = result
                        .ToLambda()
                        .Compile()
                        .DynamicInvoke()
                        .ThrowIfNull()
                        .ToConstant();

                    fields.CacheSingleton.Add(type, constant);

                    return true;
                }

                return false;
            }
            case InjectorItemType.Transient:
            {
                var isFull = UpdateParameters(injectorItem.Expression, out result);

                return isFull;
            }
            default:
            {
                throw new UnreachableException();
            }
        }
    }

    private bool UpdateParameters(Expression expression, out Expression result)
    {
        var isFull = true;

        switch (expression)
        {
            case InvocationExpression invocationExpression:
            {
                var arguments = new List<Expression>();

                foreach (var argument in invocationExpression.Arguments)
                {
                    if (!UpdateParameters(argument, result: out var value))
                    {
                        isFull = false;
                    }

                    arguments.Add(value);
                }

                result = invocationExpression.Update(invocationExpression.Expression, arguments);

                break;
            }
            case ParameterExpression parameterExpression:
            {
                var parameter = CreateParameter(parameterExpression);

                if (parameter is ParameterExpression)
                {
                    isFull = false;
                }

                result = parameter;

                break;
            }
            case LambdaExpression lambdaExpression:
            {
                var expressions = new List<Expression>();

                foreach (var parameter in lambdaExpression.Parameters)
                {
                    if (!UpdateParameters(parameter, result: out var value))
                    {
                        isFull = false;
                    }

                    expressions.Add(value);
                }

                result = lambdaExpression.ToInvoke(expressions);

                break;
            }
            case NewExpression newExpression:
            {
                var arguments = new List<Expression>();

                var parameters = newExpression.Constructor is null
                    ? Array.Empty<ParameterInfo>()
                    : newExpression.Constructor.GetParameters();

                var reserveds =
                    new Dictionary<int, (TypeInformation Type, InjectorItem InjectorItem)>();

                for (var index = 0; index < parameters.Length; index++)
                {
                    var identifier = new ReservedCtorParameterIdentifier(
                        newExpression.Type,
                        Constructor: newExpression.Constructor.ThrowIfNull(),
                        Parameter: parameters[index]
                    );

                    if (
                        !fields.ReservedCtorParameters.TryGetValue(identifier, value: out var injectorItem)
                    )
                    {
                        continue;
                    }

                    reserveds.Add(index, value: (identifier.Parameter.ParameterType, injectorItem));
                }

                for (var index = 0; index < newExpression.Arguments.Count; index++)
                {
                    if (reserveds.TryGetValue(index, value: out var item))
                    {
                        if (!BuildExpression(item.Type, item.InjectorItem, result: out var reserved))
                        {
                            isFull = false;
                        }

                        arguments.Add(reserved.ThrowIfNull());

                        continue;
                    }

                    var argument = newExpression.Arguments[index];

                    if (!UpdateParameters(argument, result: out var value))
                    {
                        isFull = false;
                    }

                    arguments.Add(value);
                }

                result = newExpression.Update(arguments);

                break;
            }
            case MethodCallExpression methodCallExpression:
            {
                var arguments = new List<Expression>();

                foreach (var argument in methodCallExpression.Arguments)
                {
                    if (!UpdateParameters(argument, result: out var value))
                    {
                        isFull = false;
                    }

                    arguments.Add(value);
                }

                if (methodCallExpression.Object is null)
                {
                    result = methodCallExpression.Update(methodCallExpression.Object, arguments);
                }
                else
                {
                    if (!UpdateParameters(methodCallExpression.Object, result: out var obj))
                    {
                        isFull = false;
                    }

                    result = methodCallExpression.Update(obj, arguments);
                }

                break;
            }
            case ConstantExpression constantExpression:
            {
                result = constantExpression;

                break;
            }
            default:
            {
                var type = expression.GetType();

                throw new UnreachableException(message: type.ToString());
            }
        }

        if (!AutoInjectMembers(result, out result))
        {
            isFull = false;
        }

        return isFull;
    }

    private bool AutoInjectMembers(Expression root, out Expression result)
    {
        var isFull = true;
        var variables = new List<ParameterExpression>();
        var members = root.Type.GetMembers();
        var memberExpressions = new List<(MemberInfo Member, Expression Expression)>();

        foreach (var member in members)
        {
            var identifier = new AutoInjectMemberIdentifier(root.Type, member);

            if (!fields.AutoInjectMembers.TryGetValue(identifier, value: out var injectorItem))
            {
                continue;
            }

            if (
                injectorItem.Expression is LambdaExpression lambdaExpression
                && lambdaExpression.Parameters.IsSingle()
                && lambdaExpression.Body is ParameterExpression parameterExpression
                && lambdaExpression.Parameters[index: 0].Type == parameterExpression.Type
            )
            {
                var type = parameterExpression.ThrowIfNull().Type;

                if (fields.Injectors.ContainsKey(type))
                {
                    injectorItem = fields.Injectors[parameterExpression.Type];
                }
                else
                {
                    variables.Add(parameterExpression);
                    memberExpressions.Add(item: (member, parameterExpression));
                    isFull = false;

                    continue;
                }
            }

            if (!BuildExpression(identifier.Member.Type, injectorItem, result: out var expression))
            {
                expression = expression.ThrowIfNull();
                variables.AddRange(collection: GetParameters(expression.ThrowIfNull()));
                isFull = false;
            }

            memberExpressions.Add(item: (member, expression));
        }

        if (memberExpressions.IsEmpty())
        {
            result = root;

            return isFull;
        }

        var blockItems = new List<Expression>();
        var rootVariable = root.Type.ToVariableAutoName();
        blockItems.Add(item: rootVariable.ToAssign(root));

        foreach (var memberExpression in memberExpressions)
        {
            var assign = rootVariable
                .ToMember(memberExpression.Member)
                .ToAssign(memberExpression.Expression);

            blockItems.Add(assign);
        }

        blockItems.Add(rootVariable);
        result = variables.ToBlock(blockItems);

        return isFull;
    }

    private IEnumerable<ParameterExpression> GetParameters(Expression expression)
    {
        switch (expression)
        {
            case InvocationExpression invocationExpression:
            {
                foreach (var argument in invocationExpression.Arguments)
                {
                    foreach (var parameter in GetParameters(argument))
                    {
                        yield return parameter;
                    }
                }

                break;
            }
            case ParameterExpression parameterExpression:
            {
                yield return parameterExpression;

                break;
            }
            case LambdaExpression lambdaExpression:
            {
                foreach (var parameter in lambdaExpression.Parameters)
                {
                    yield return parameter;
                }

                break;
            }
            case NewExpression newExpression:
            {
                foreach (var argument in newExpression.Arguments)
                {
                    foreach (var parameter in GetParameters(argument))
                    {
                        yield return parameter;
                    }
                }

                break;
            }
            case MethodCallExpression methodCallExpression:
            {
                foreach (var argument in methodCallExpression.Arguments)
                {
                    foreach (var parameter in GetParameters(argument))
                    {
                        yield return parameter;
                    }
                }

                if (methodCallExpression.Object is not null)
                {
                    foreach (var parameter in GetParameters(methodCallExpression.Object))
                    {
                        yield return parameter;
                    }
                }

                break;
            }
            case ConstantExpression:
            {
                break;
            }
            default:
            {
                var type = expression.GetType();

                throw new UnreachableException(message: type.ToString());
            }
        }
    }

    private Expression CreateParameter(ParameterExpression parameterExpression)
    {
        if (!fields.Injectors.TryGetValue(parameterExpression.Type, value: out var injectorItem))
        {
            return parameterExpression;
        }

        BuildExpression(parameterExpression.Type, injectorItem, result: out var result);

        return result.ThrowIfNull();
    }

    private Func<object> BuildFunc(Expression expression)
    {
        var result = expression.ToLambda().Compile().ThrowIfIsNot<Func<object>>();

        return result;
    }

    #region Checks

    private void Check(IReadOnlyDictionary<TypeInformation, InjectorItem> injectors)
    {
        CheckInjectors(injectors);
    }

    private void CheckInjectors(IReadOnlyDictionary<TypeInformation, InjectorItem> injectors)
    {
        var listParameterTypes = new List<TypeInformation>();

        foreach (var injector in injectors)
        {
            var keyType = injector.Key.Type;
            var injectorType = injector.Value.Expression.Type;
            var isAssignableFrom = injector.Value.Expression.Type.IsAssignableFrom(keyType);

            if (keyType != injectorType && isAssignableFrom)
            {
                throw new NotCovertException(injector.Key.Type, injector.Value.Expression.Type);
            }

            var types = GetParameters(injector.Value.Expression)
                .Select(selector: x => (TypeInformation)x.Type);

            listParameterTypes.AddRange(types);

            if (listParameterTypes.Contains(injector.Key.Type))
            {
                throw new RecursionTypeExpressionInvokeException(
                    injector.Key.Type,
                    injector.Value.Expression
                );
            }

            listParameterTypes.Clear();
        }
    }

    #endregion
}