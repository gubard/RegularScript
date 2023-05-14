namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IRegisterAutoInjectMember
    : IRegisterTransientAutoInjectMember,
        IRegisterSingletonAutoInjectMember,
        IRegisterScopeAutoInjectMember
{
}