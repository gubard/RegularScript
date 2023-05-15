using System;
using System.Linq;

namespace RegularScript.Core.DependencyInjection.Extensions;

public static class DelegateExtension
{
    public static Type[] GetParameterTypes(this Delegate del)
    {
        return del.Method.GetParameters().Select(x => x.ParameterType).ToArray();
    }
}