using System.Linq.Expressions;
using RegularScript.Core.DependencyInjection.Exceptions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.Expressions.Extensions;

namespace RegularScript.Core.DependencyInjection.Extensions;

public static class RegisterTransientExtension
{
    public static void RegisterTransientDel<T>(
        this IRegisterTransient registerTransient,
        Delegate del
    )
    {
        registerTransient.RegisterTransient(
            type: typeof(T),
            expression: del.ToCall(
                arguments: del.Method.GetParameters().Select(selector: x => x.ParameterType.ToVariableAutoName()))
        );
    }

    public static void RegisterTransient<T>(
        this IRegisterTransient registerTransient,
        Expression @delegate
    )
    {
        registerTransient.RegisterTransient(type: typeof(T), @delegate);
    }

    public static void RegisterTransient<T>(
        this IRegisterTransient registerTransient,
        Expression<Func<T>> func
    )
    {
        registerTransient.RegisterTransient(type: typeof(T), func);
    }

    public static void RegisterTransient<T>(this IRegisterTransient registerTransient)
        where T : notnull
    {
        registerTransient.RegisterTransient<T, T>();
    }

    public static void RegisterTransient(
        this IRegisterTransient registerTransient,
        Type id,
        Type impType
    )
    {
        var constructor = impType.GetSingleConstructor();

        if (constructor is null)
        {
            if (impType.IsValueType)
            {
                var lambdaNew = impType.ToNew();
                registerTransient.RegisterTransient(id, lambdaNew);

                return;
            }

            throw new NotHaveConstructorException(impType);
        }

        var parameters = constructor.GetParameters();

        if (parameters.Length == 0)
        {
            var lambdaNew = impType.ToNew();
            registerTransient.RegisterTransient(id, lambdaNew);

            return;
        }

        var expressions = parameters.Select(selector: x => x.ParameterType.ToParameterAutoName()).ToArray();
        var expressionNew = constructor.ToNew(expressions);
        registerTransient.RegisterTransient(id, expressionNew);
    }

    public static void RegisterTransient<T, TImp>(this IRegisterTransient registerTransient)
        where TImp : notnull, T
    {
        registerTransient.RegisterTransient(id: typeof(T), impType: typeof(TImp));
    }

    public static void RegisterTransient(this IRegisterTransient registerTransient, Type id)
    {
        registerTransient.RegisterTransient(id, id);
    }
}