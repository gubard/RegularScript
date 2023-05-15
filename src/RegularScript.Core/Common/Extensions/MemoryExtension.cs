using System;

namespace RegularScript.Core.Common.Extensions;

public static class MemoryExtension
{
    public static T GetSingle<T>(this Memory<T> memory)
    {
        if (memory.Length == 1)
        {
            return memory.Span[0];
        }

        throw new Exception(memory.Length.ToString());
    }
}