using System.Linq.Expressions;
using RegularScript.Core.DependencyInjection.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IRegisterScopeAutoInjectMember
{
    void RegisterScopeAutoInjectMember(
        AutoInjectMemberIdentifier memberIdentifier,
        Expression expression
    );
}