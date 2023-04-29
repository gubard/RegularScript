namespace RegularScript.Core.Common.Exceptions;

public class NotCovertException : Exception
{
    public Type CurrentType { get; }
    public Type ExpectedType { get; }

    public NotCovertException(Type currentType, Type expectedType)
        : base(message: $"Can't convert {currentType} to {expectedType}.")
    {
        CurrentType = currentType;
        ExpectedType = expectedType;
    }
}