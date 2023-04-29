namespace RegularScript.Core.DependencyInjection.Exceptions;

public class NotHaveConstructorException : Exception
{
    public Type Type { get; }

    public NotHaveConstructorException(Type type) : base(message: $"Type {type} not have constructor.")
    {
        Type = type;
    }
}