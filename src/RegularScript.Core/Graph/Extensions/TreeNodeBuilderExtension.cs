using RegularScript.Core.Graph.Services;

namespace RegularScript.Core.Graph.Extensions;

public static class TreeNodeBuilderExtension
{
    public static TreeNodeBuilder<TKey, TValue> SetKey<TKey, TValue>(
        this TreeNodeBuilder<TKey, TValue> builder,
        TKey key) where TKey : notnull
    {
        builder.Key = key;

        return builder;
    }

    public static TreeNodeBuilder<TKey, TValue> SetValue<TKey, TValue>(
        this TreeNodeBuilder<TKey, TValue> builder,
        TValue value) where TKey : notnull
    {
        builder.Value = value;

        return builder;
    }
}