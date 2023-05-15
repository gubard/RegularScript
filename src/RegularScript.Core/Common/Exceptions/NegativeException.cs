using System;

namespace RegularScript.Core.Common.Exceptions;

public class NegativeException<TValue> : Exception
{
    public NegativeException(string name, TValue value)
        : base($"{name}({value}) can't be negative.")
    {
        Name = name;
        Value = value;
    }

    public string Name { get; }
    public TValue Value { get; }
}