﻿using System.Diagnostics;
using System.Linq.Expressions;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Common.Models;
using RegularScript.Core.DependencyInjection.Exceptions;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Models;
using RegularScript.Core.Expressions.Extensions;
using RegularScript.Core.Graph.Extensions;
using RegularScript.Core.Graph.Models;
using RegularScript.Core.ModularSystem.Interfaces;

namespace RegularScript.Core.ModularSystem.Services;

public class ModuleTree : IModule, IResolver, IInvoker
{
    private readonly Tree<Guid, IModule> tree;
    private readonly Dictionary<TypeInformation, Func<object>> cache;
    private readonly Expression thisExpression;

    public ModuleTree(Tree<Guid, IModule> tree)
    {
        this.tree = tree;
        cache = new ();
        Id = Guid.NewGuid();
        var inputs = new List<TypeInformation>();
        var outputs = new List<TypeInformation>();
        var ends = this.tree.GetEnds();

        foreach (var node in ends)
        {
            AddTypes(inputs, outputs, node);
        }

        var defaultTypes = new TypeInformation[]
        {
            typeof(IResolver),
            typeof(IInvoker)
        };

        var outputsArray = outputs
           .Distinct()
           .Concat(defaultTypes)
           .OrderBy(x => x.ToString())
           .ToArray();

        Outputs = outputsArray;
        Inputs = inputs.Distinct().Where(x => !outputsArray.Contains(x)).ToArray();
        thisExpression = this.ToConstant();
    }

    public Guid Id { get; }
    public ReadOnlyMemory<TypeInformation> Inputs { get; }
    public ReadOnlyMemory<TypeInformation> Outputs { get; }
    public bool IsFull => Inputs.IsEmpty;

    public DependencyStatus GetStatus(TypeInformation type)
    {
        if (typeof(IResolver) == type)
        {
            return new (type, thisExpression);
        }

        if (typeof(IInvoker) == type)
        {
            return new (type, thisExpression);
        }

        if (!Outputs.Span.Contains(type))
        {
            throw new TypeNotRegisterException(type.Type);
        }

        if (tree.Root.Value.Outputs.Span.Contains(type))
        {
            var rootStatus = tree.Root.Value.GetStatus(type);

            return rootStatus;
        }

        var status = GetDependencyStatus(tree.Root, type).ThrowIfNullStruct();

        return status;
    }

    public object GetObject(TypeInformation type)
    {
        if (typeof(IResolver) == type)
        {
            return this;
        }

        if (typeof(IInvoker) == type)
        {
            return this;
        }

        if (!Outputs.Span.Contains(type))
        {
            throw new TypeNotRegisterException(type.Type);
        }

        if (cache.TryGetValue(type, out var func))
        {
            var value = func.Invoke();

            return value;
        }

        var status = GetStatus(type);
        var expression = UpdateExpression(status.Expression);

        if (expression.Type.IsValueType)
        {
            expression = expression.ToConvert(typeof(object));
        }

        var lambda = expression.ToLambda();
        func = lambda.Compile().ThrowIfIsNot<Func<object>>();
        var result = func.Invoke();
        cache.Add(type, func);

        return result;
    }

    public object Resolve(TypeInformation type)
    {
        return GetObject(type);
    }

    private Expression UpdateExpression(Expression expression)
    {
        switch (expression)
        {
            case InvocationExpression invocationExpression:
            {
                var arguments = new List<Expression>();

                foreach (var argument in invocationExpression.Arguments)
                {
                    arguments.Add(UpdateExpression(argument));
                }

                var innerExpression = invocationExpression.Expression;
                var result = invocationExpression.Update(innerExpression, arguments);

                return result;
            }
            case ParameterExpression parameterExpression:
            {
                var result = CreateParameter(parameterExpression);

                return result;
            }
            case NewExpression newExpression:
            {
                var arguments = new List<Expression>();

                foreach (var argument in newExpression.Arguments)
                {
                    var argumentExpression = UpdateExpression(argument);

                    if (argumentExpression.Type.IsValueType)
                    {
                        argumentExpression = argumentExpression.ToConvert(argument.Type);
                    }

                    arguments.Add(argumentExpression);
                }

                return newExpression.Update(arguments);
            }
            case BlockExpression blockExpression:
            {
                var expressions = new List<Expression>();
                var count = blockExpression.Expressions.Count - 1;
                var blockExpressionItems = blockExpression.Expressions.Take(count);

                var blockResult = blockExpression.Expressions
                   .Last()
                   .ThrowIfIsNot<ParameterExpression>();

                foreach (var blockExpressionItem in blockExpressionItems)
                {
                    expressions.Add(UpdateExpression(blockExpressionItem));
                }

                expressions.Add(blockResult);
                var result = blockExpression.Update(blockResult.AsArray(), expressions);

                return result;
            }
            case ConstantExpression constantExpression:
            {
                return constantExpression;
            }
            case BinaryExpression binaryExpression:
            {
                var conversion = binaryExpression.Conversion is null
                    ? null
                    : UpdateExpression(binaryExpression).ThrowIfIsNot<LambdaExpression>();

                var right = UpdateExpression(binaryExpression.Right);
                var result = binaryExpression.Update(binaryExpression.Left, conversion, right);

                return result;
            }
            case MethodCallExpression methodCallExpression:
            {
                var obj = methodCallExpression.Object is null
                    ? null
                    : UpdateExpression(methodCallExpression.Object);

                var arguments = new List<Expression>();

                foreach (var argument in methodCallExpression.Arguments)
                {
                    arguments.Add(UpdateExpression(argument));
                }

                return methodCallExpression.Update(obj, arguments);
            }
            default:
            {
                var type = expression.GetType();

                throw new UnreachableException(type.ToString());
            }
        }
    }

    private Expression CreateParameter(ParameterExpression parameterExpression)
    {
        var status = GetStatus(parameterExpression.Type);
        var expression = UpdateExpression(status.Expression);

        return expression;
    }

    private DependencyStatus? GetDependencyStatus(
        TreeNode<Guid, IModule> node,
        TypeInformation type
    )
    {
        if (typeof(IResolver) == type)
        {
            return new DependencyStatus(type, thisExpression);
        }

        if (typeof(IInvoker) == type)
        {
            return new DependencyStatus(type, thisExpression);
        }

        foreach (var treeNode in node.Nodes)
        {
            if (treeNode.Value.Outputs.Span.Contains(type))
            {
                var status = treeNode.Value.GetStatus(type);

                return status;
            }
        }

        foreach (var treeNode in node.Nodes)
        {
            var status = GetDependencyStatus(treeNode, type);

            if (status is null)
            {
                continue;
            }

            return status;
        }

        throw new TypeNotRegisterException(type.Type);
    }

    private void AddTypes(
        List<TypeInformation> inputs,
        List<TypeInformation> outputs,
        TreeNode<Guid, IModule> node
    )
    {
        outputs.AddRange(node.Value.Outputs.ToArray());
        inputs.AddRange(node.Value.Inputs.ToArray());

        if (node.Parent is null)
        {
            return;
        }

        AddTypes(inputs, outputs, node.Parent);
    }

    public object? Invoke(Delegate del, DictionarySpan<TypeInformation, object> arguments)
    {
        var parameterTypes = del.GetParameterTypes();
        var args = new object[parameterTypes.Length];

        for (var index = 0; index < args.Length; index++)
        {
            if (arguments.TryGetValue(parameterTypes[index], out var value))
            {
                args[index] = value;
            }
            else
            {
                args[index] = Resolve(parameterTypes[index]);
            }
        }

        return del.DynamicInvoke(args);
    }
}