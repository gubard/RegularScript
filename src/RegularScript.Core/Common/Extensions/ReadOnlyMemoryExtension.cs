using System.Diagnostics.CodeAnalysis;

namespace RegularScript.Core.Common.Extensions;

public static class ReadOnlyMemoryExtension
{
    public static bool IsSingleValue<T>(this ReadOnlyMemory<T> memory)
    {
        if (memory.Length == 1)
        {
            return true;
        }

        return false;
    }

    public static T GetSingle<T>(this ReadOnlyMemory<T> memory)
    {
        if (memory.Length == 1)
        {
            return memory.Span[index: 0];
        }

        throw new (message: memory.Length.ToString());
    }

    public static bool TryGetSingleValue<T>(
        this ReadOnlyMemory<T> memory,
        [MaybeNullWhen(returnValue: false)] out T value
    )
    {
        if (memory.IsSingleValue())
        {
            value = memory.Span[index: 0];

            return true;
        }

        value = default;

        return false;
    }
}