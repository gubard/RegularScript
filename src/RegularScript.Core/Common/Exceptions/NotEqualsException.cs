namespace RegularScript.Core.Common.Exceptions;

public class NotEqualsException<TValue> : Exception
{
    public string Name { get; }
    public TValue Value { get; }
    public TValue Expected { get; }

    public NotEqualsException(string name, TValue value, TValue expected)
        : base(message: $"{name} equals {value} expected {expected}.")
    {
        Name = name;
        Value = value;
        Expected = expected;
    }
}