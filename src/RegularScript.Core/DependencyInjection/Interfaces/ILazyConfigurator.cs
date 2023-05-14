using RegularScript.Core.Common.Models;
using RegularScript.Core.DependencyInjection.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface ILazyConfigurator
{
    void SetLazyOptions(TypeInformation type, LazyDependencyInjectorOptions options);
}