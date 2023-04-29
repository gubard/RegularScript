namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IRegisterReservedCtorParameter
    : IRegisterSingletonReservedCtorParameter,
        IRegisterTransientReservedCtorParameter
{
}