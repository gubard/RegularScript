using RegularScript.Core.Common.Models;
using RegularScript.Core.DependencyInjection.Interfaces;

namespace RegularScript.Core.ModularSystem.Interfaces;

public interface IModule : IDependencyStatusGetter
{
    Guid Id { get; }
    ReadOnlyMemory<TypeInformation> Inputs { get; }
    ReadOnlyMemory<TypeInformation> Outputs { get; }

    object GetObject(TypeInformation type);
}
