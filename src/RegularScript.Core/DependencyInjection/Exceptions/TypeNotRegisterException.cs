namespace RegularScript.Core.DependencyInjection.Exceptions;

public class TypeNotRegisterException : Exception
{
    public Type Type { get; }

    public TypeNotRegisterException(Type type) : base(message: $"Type {type} not register.")
    {
        Type = type;
    }
}