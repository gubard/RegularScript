using RegularScript.Core.Common.Extensions;
using RegularScript.Core.ModularSystem.Interfaces;

namespace RegularScript.Core.ModularSystem.Extensions;

public static class ModuleTreeExtension
{
    public static T GetObject<T>(this IModule module)
    {
        return module.GetObject(typeof(T)).ThrowIfIsNot<T>();
    }
}