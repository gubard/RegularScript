namespace RegularScript.Core.DependencyInjection.Exceptions;

public class NotFondConstructorException : Exception
{
    public Type Type { get; }
    public Type TypeParameter { get; }

    public NotFondConstructorException(Type type, Type typeParameter)
        : base(message: $"Type {type} not have constructor with parameter type {typeParameter}.")
    {
        Type = type;
        TypeParameter = typeParameter;
    }
}