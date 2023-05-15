using System.Collections.Generic;

namespace RegularScript.Core.Common.Helpers;

public static class ReadOnlyDictionaryClass<TKey, TValue> where TKey : notnull
{
    public static readonly IReadOnlyDictionary<TKey, TValue> Empty = new Dictionary<TKey, TValue>();
}