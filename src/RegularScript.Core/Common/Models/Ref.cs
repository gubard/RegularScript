﻿namespace RegularScript.Core.Common.Models;

public class Ref<T> where T : struct
{
    public Ref(T value)
    {
        Value = value;
    }

    public T Value { get; set; }

    public static implicit operator T(Ref<T> @ref)
    {
        return @ref.Value;
    }

    public static implicit operator Ref<T>(T @ref)
    {
        return new Ref<T>(@ref);
    }
}