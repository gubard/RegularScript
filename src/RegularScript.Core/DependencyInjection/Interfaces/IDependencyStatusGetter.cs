using RegularScript.Core.Common.Models;
using RegularScript.Core.DependencyInjection.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IDependencyStatusGetter
{
    DependencyStatus GetStatus(
        TypeInformation type,
        Dictionary<TypeInformation, ScopeValue> scopeParameters
    );
}