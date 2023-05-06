using System.Linq.Expressions;
using System.Reflection;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Core.DependencyInjection.Exceptions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.Expressions.Extensions;

namespace RegularScript.Core.DependencyInjection.Extensions;

public static class DependencyInjectorRegisterExtension
{
    public static void RegisterTransient<T>(this IDependencyInjectorRegister registerTransient)
        where T : notnull
    {
        registerTransient.RegisterTransient<T, T>();
    }

    public static void RegisterTransient<T, TImp>(this IDependencyInjectorRegister registerTransient)
        where TImp : notnull, T
    {
        registerTransient.RegisterTransient(id: typeof(T), impType: typeof(TImp));
    }

    public static void RegisterTransient<TDependencyInjectorRegister>(
        this TDependencyInjectorRegister registerTransient,
        Type id)
        where TDependencyInjectorRegister : IDependencyInjectorRegister
    {
        registerTransient.RegisterTransient(id, id);
    }

    public static void RegisterTransient<TDependencyInjectorRegister>(
        this TDependencyInjectorRegister registerTransient,
        Type id,
        Type impType
    ) where TDependencyInjectorRegister : IDependencyInjectorRegister
    {
        var constructor = impType.GetSingleConstructor();
        var properties = impType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty);

        foreach (var property in properties)
        {
            var attribute = property.GetCustomAttribute<InjectAttribute>();

            if (attribute is null)
            {
                continue;
            }

            var parameter = impType.ToParameterAutoName();
            var lambda = Expression.Property(parameter, property).ToLambda(parameter);
            registerTransient.RegisterTransientAutoInject(lambda);
        }

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

    public static void RegisterConfigurationFromAssemblies<TDependencyInjectorRegister>(
        this TDependencyInjectorRegister register
    ) where TDependencyInjectorRegister : IDependencyInjectorRegister
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        register.RegisterConfigurationFromAssemblies(assemblies);
    }

    public static void RegisterConfigurationFromAssemblies<TDependencyInjectorRegister>(
        this TDependencyInjectorRegister register,
        IEnumerable<Assembly> assemblies
    ) where TDependencyInjectorRegister : IDependencyInjectorRegister
    {
        foreach (var assembly in assemblies)
        {
            register.RegisterConfigurationFromAssembly(assembly);
        }
    }

    public static void RegisterConfigurationFromAssembly<TDependencyInjectorRegister>(
        this TDependencyInjectorRegister register,
        Assembly assembly
    ) where TDependencyInjectorRegister : IDependencyInjectorRegister
    {
        var types = assembly.GetTypes();

        var dependencyInjectorConfigurations = types
           .Where(
                predicate: x =>
                    x is { IsInterface: false, IsAbstract: false, }
                 && typeof(IDependencyInjectorConfiguration).IsAssignableFrom(x)
            )
           .ToArray();

        foreach (var type in dependencyInjectorConfigurations)
        {
            var dependencyInjectorConfiguration = Activator
               .CreateInstance(type)
               .ThrowIfNull()
               .ThrowIfIsNot<IDependencyInjectorConfiguration>();

            register.RegisterConfiguration(dependencyInjectorConfiguration);
        }
    }

    public static void RegisterConfiguration<TDependencyInjectorConfiguration>(
        this IDependencyInjectorRegister register
    ) where TDependencyInjectorConfiguration : IDependencyInjectorConfiguration, new()
    {
        new TDependencyInjectorConfiguration().Configure(register);
    }
}