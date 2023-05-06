using RegularScript.Core.Common.Models;
using RegularScript.Core.DependencyInjection.Exceptions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Models;
using RegularScript.Core.ModularSystem.Interfaces;

namespace RegularScript.Core.ModularSystem.Services;

public class Module : IModule
{
    private readonly IDependencyInjector dependencyInjector;

    public Module(Guid id, IDependencyInjector dependencyInjector)
    {
        this.dependencyInjector = dependencyInjector;
        Id = id;
    }

    public Guid Id { get; }
    public ReadOnlyMemory<TypeInformation> Inputs => dependencyInjector.Inputs;
    public ReadOnlyMemory<TypeInformation> Outputs => dependencyInjector.Outputs;

    public object GetObject(TypeInformation type)
    {
        if (!Outputs.Span.Contains(type))
        {
            throw new TypeNotRegisterException(type.Type);
        }

        return dependencyInjector.Resolve(type);
    }

    public DependencyStatus GetStatus(TypeInformation type)
    {
        var status = dependencyInjector.GetStatus(type);

        return status;
    }
}
