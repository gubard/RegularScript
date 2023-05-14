﻿using RegularScript.Core.Common.Interfaces;

namespace RegularScript.Core.Common.Models;

public abstract class Identifier<TKey> : IIdentifier<TKey> where TKey : notnull
{
    public Identifier(TKey key)
    {
        Key = key;
    }

    public TKey Key { get; }

    public override int GetHashCode()
    {
        return EqualityComparer<TKey>.Default.GetHashCode(Key);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;

        if (ReferenceEquals(this, obj)) return true;

        if (obj is not IIdentifier<TKey> identifier) return false;

        return identifier.Key.Equals(Key);
    }
}

public class Identifier2<TKey1, TKey2>
    where TKey1 : notnull
    where TKey2 : notnull
{
    public Identifier2(TKey1 key1, TKey2 key2)
    {
        Key1 = key1;
        Key2 = key2;
    }

    public TKey1 Key1 { get; }
    public TKey2 Key2 { get; }

    public override int GetHashCode()
    {
        var hashCodeBuilder = new HashCode();
        hashCodeBuilder.Add(EqualityComparer<TKey1>.Default.GetHashCode(Key1));
        hashCodeBuilder.Add(EqualityComparer<TKey2>.Default.GetHashCode(Key2));

        return hashCodeBuilder.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;

        if (ReferenceEquals(this, obj)) return true;

        if (obj is not Identifier2<TKey1, TKey2> identifier) return false;

        return identifier.Key1.Equals(Key1) && identifier.Key2.Equals(Key2);
    }
}

public class Identifier<TKey, TValue> : IIdentifier<TKey>
{
    public Identifier(TKey key, TValue value)
    {
        Key = key;
        Value = value;
    }

    public TValue Value { get; }

    public TKey Key { get; }
}