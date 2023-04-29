using System.Linq.Expressions;
using RegularScript.Core.DependencyInjection.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IRegisterTransientReservedCtorParameter
{
    void RegisterTransientReservedCtorParameter(
        ReservedCtorParameterIdentifier identifier,
        Expression expression
    );
}