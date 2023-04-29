namespace RegularScript.Core.DependencyInjection.Exceptions;

public class ToManyConstructorsException : Exception
{
    public Type Type { get; }
    public int Count { get; }
    public int ExpectedCount { get; }

    public ToManyConstructorsException(Type type, int expectedCount, int count)
        : base(message: $"Type {type} have {count} constructors, expected count {expectedCount}.")
    {
        Type = type;
        Count = count;
        ExpectedCount = expectedCount;
    }
}