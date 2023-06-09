using System.Collections.Generic;

namespace RegularScript.Core.Common.Extensions;

public static class HashSetExtension
{
    public static bool TryAdd<T>(this HashSet<T> set, T item)
    {
        if (set.Contains(item))
        {
            return false;
        }

        set.Add(item);

        return false;
    }
}