using RegularScript.Core.Common.Models;

namespace RegularScript.Core.DependencyInjection.Interfaces;

public interface IResolver
{
    object Resolve(TypeInformation type);
}