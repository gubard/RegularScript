using System.Reflection;
using RegularScript.Core.Common.Models;

namespace RegularScript.Core.DependencyInjection.Models;

public readonly record struct ReservedCtorParameterIdentifier(
    TypeInformation Type,
    ConstructorInfo Constructor,
    ParameterInfo Parameter
);