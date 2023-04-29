using System.Linq.Expressions;
using RegularScript.Core.DependencyInjection.Interfaces;

namespace RegularScript.Core.DependencyInjection.Extensions;

public static class RegisterSingletonExtension
{
    public static void RegisterSingleton<T>(
        this IRegisterSingleton registerSingleton,
        Expression expression
    )
    {
        registerSingleton.RegisterSingleton(type: typeof(T), expression);
    }

    public static void RegisterSingleton<T>(this IRegisterSingleton registerSingleton)
    {
        registerSingleton.RegisterSingleton<T>(expression: (T value) => value);
    }

    public static void RegisterSingleton<T>(this IRegisterSingleton registerSingleton, T value)
    {
        registerSingleton.RegisterSingleton(type: typeof(T), expression: () => value);
    }

    public static void RegisterSingleton<T, TImp>(this IRegisterSingleton registerSingleton)
        where TImp : notnull, T
    {
        registerSingleton.RegisterSingleton<T>(expression: (TImp imp) => imp);
    }
}