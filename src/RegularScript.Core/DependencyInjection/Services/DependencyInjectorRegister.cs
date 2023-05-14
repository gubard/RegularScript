using System.Linq.Expressions;
using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.Common.Models;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Models;

namespace RegularScript.Core.DependencyInjection.Services;

public class DependencyInjectorRegister : IBuilder<DependencyInjector>, IDependencyInjectorRegister
{
    private readonly Dictionary<AutoInjectMemberIdentifier, InjectorItem> autoInjectMembers;
    private readonly Dictionary<TypeInformation, InjectorItem> injectors;
    private readonly Dictionary<TypeInformation, LazyDependencyInjectorOptions> lazyOptions;

    private readonly Dictionary<
        ReservedCtorParameterIdentifier,
        InjectorItem
    > reservedCtorParameters;

    public DependencyInjectorRegister()
    {
        lazyOptions = new Dictionary<TypeInformation, LazyDependencyInjectorOptions>();
        reservedCtorParameters = new Dictionary<ReservedCtorParameterIdentifier, InjectorItem>();
        injectors = new Dictionary<TypeInformation, InjectorItem>();
        autoInjectMembers = new Dictionary<AutoInjectMemberIdentifier, InjectorItem>();
    }

    public DependencyInjector Build()
    {
        var dependencyInjector = new DependencyInjector(
            injectors,
            autoInjectMembers,
            reservedCtorParameters,
            lazyOptions
        );

        return dependencyInjector;
    }

    public void RegisterConfiguration(IDependencyInjectorConfiguration configuration)
    {
        configuration.Configure(this);
    }

    public void RegisterTransient(Type type, Expression expression)
    {
        RegisterTransientCore(type, expression);
    }

    public void RegisterSingleton(Type type, Expression expression)
    {
        RegisterSingletonCore(type, expression);
    }

    public void RegisterTransientAutoInjectMember(
        AutoInjectMemberIdentifier memberIdentifier,
        Expression expression
    )
    {
        var injectorItem = new InjectorItem(InjectorItemType.Transient, expression);
        autoInjectMembers[memberIdentifier] = injectorItem;
    }

    public void RegisterSingletonAutoInjectMember(
        AutoInjectMemberIdentifier memberIdentifier,
        Expression expression
    )
    {
        var injectorItem = new InjectorItem(InjectorItemType.Singleton, expression);
        autoInjectMembers[memberIdentifier] = injectorItem;
    }

    public void RegisterSingletonReservedCtorParameter(
        ReservedCtorParameterIdentifier identifier,
        Expression expression
    )
    {
        var injectorItem = new InjectorItem(InjectorItemType.Singleton, expression);
        reservedCtorParameters[identifier] = injectorItem;
    }

    public void RegisterTransientReservedCtorParameter(
        ReservedCtorParameterIdentifier identifier,
        Expression expression
    )
    {
        var injectorItem = new InjectorItem(InjectorItemType.Transient, expression);
        reservedCtorParameters[identifier] = injectorItem;
    }

    public void RegisterScope(Type type, Expression expression)
    {
        injectors[type] = new InjectorItem(InjectorItemType.Scope, expression);
    }

    public void SetLazyOptions(TypeInformation type, LazyDependencyInjectorOptions options)
    {
        lazyOptions[type] = options;
    }

    public void RegisterScopeAutoInjectMember(AutoInjectMemberIdentifier memberIdentifier, Expression expression)
    {
        var injectorItem = new InjectorItem(InjectorItemType.Scope, expression);
        autoInjectMembers[memberIdentifier] = injectorItem;
    }

    private void RegisterTransientCore(Type type, Expression expression)
    {
        injectors[type] = new InjectorItem(InjectorItemType.Transient, expression);
    }

    public void RegisterSingletonCore(Type type, Expression expression)
    {
        injectors[type] = new InjectorItem(InjectorItemType.Singleton, expression);
    }
}