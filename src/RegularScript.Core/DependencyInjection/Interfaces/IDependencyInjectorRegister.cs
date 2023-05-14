namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IDependencyInjectorRegister
    : IRegisterTransient,
        IRegisterSingleton,
        IRegisterAutoInjectMember,
        IRegisterConfiguration,
        IRegisterReservedCtorParameter,
        IRegisterScope,
        ILazyConfigurator
{
}