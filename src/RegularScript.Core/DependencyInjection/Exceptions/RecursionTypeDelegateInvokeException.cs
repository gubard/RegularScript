namespace RegularScript.Core.DependencyInjection.Exceptions;

public class RecursionTypeDelegateInvokeException : Exception
{
    public Type Type { get; }
    public Delegate Delegate { get; }

    public RecursionTypeDelegateInvokeException(Type type, Delegate del)
        : base(message: $"{type} contains in parameters {del}.")
    {
        Type = type;
        Delegate = del;
    }
}