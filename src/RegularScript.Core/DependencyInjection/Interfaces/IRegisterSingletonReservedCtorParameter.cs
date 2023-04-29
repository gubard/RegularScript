using System.Linq.Expressions;
using RegularScript.Core.DependencyInjection.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IRegisterSingletonReservedCtorParameter
{
    void RegisterSingletonReservedCtorParameter(
        ReservedCtorParameterIdentifier identifier,
        Expression expression
    );
}