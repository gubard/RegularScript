using System.Linq.Expressions;
using RegularScript.Core.DependencyInjection.Exceptions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.Expressions.Extensions;

namespace RegularScript.Core.DependencyInjection.Extensions;

public static class RegisterScopeExtension
{
    public static void RegisterScope(this IRegisterScope register, Type id)
    {
        register.RegisterScope(id, id);
    }

    public static void RegisterScope<T>(this IRegisterScope register)
        where T : notnull
    {
        register.RegisterScope<T, T>();
    }

    public static void RegisterScope<T>(
        this IRegisterScope register,
        Expression expression
    )
    {
        register.RegisterScope(typeof(T), expression);
    }

    public static void RegisterScope<T>(
        this IRegisterScope register,
        Expression<Func<T>> expression
    )
    {
        register.RegisterScope(typeof(T), expression);
    }

    public static void RegisterScope<T, TImp>(this IRegisterScope register)
    {
        register.RegisterScope(typeof(T), typeof(TImp));
    }

    public static void RegisterScope(this IRegisterScope registerTransient, Type id, Type impType)
    {
        var constructor = impType.GetSingleConstructor();

        if (constructor is null)
        {
            if (impType.IsValueType)
            {
                var lambdaNew = impType.ToNew();
                registerTransient.RegisterScope(id, lambdaNew);

                return;
            }

            throw new NotHaveConstructorException(impType);
        }

        var parameters = constructor.GetParameters();

        if (parameters.Length == 0)
        {
            var lambdaNew = impType.ToNew();
            registerTransient.RegisterScope(id, lambdaNew);

            return;
        }

        var expressions = parameters.Select(x => x.ParameterType.ToParameterAutoName()).ToArray();

        var expressionNew = constructor.ToNew(expressions);
        registerTransient.RegisterScope(id, expressionNew);
    }
}