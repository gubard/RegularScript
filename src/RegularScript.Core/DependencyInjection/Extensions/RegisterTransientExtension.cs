using System.Linq.Expressions;
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
        var arguments = del.Method.GetParameters().Select(selector: x => x.ParameterType.ToVariableAutoName());
        var expression = del.ToCall(arguments);
        registerTransient.RegisterTransient(type: typeof(T), expression);
    }

    public static void RegisterTransient<T>(
        this IRegisterTransient registerTransient,
        Expression expression
    )
    {
        registerTransient.RegisterTransient(type: typeof(T), expression);
    }

    public static void RegisterTransient<T>(
        this IRegisterTransient registerTransient,
        Expression<Func<T>> func
    )
    {
        registerTransient.RegisterTransient(type: typeof(T), func);
    }
}