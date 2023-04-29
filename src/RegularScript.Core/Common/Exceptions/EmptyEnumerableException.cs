namespace RegularScript.Core.Common.Exceptions;

public class EmptyEnumerableException : Exception
{
    public EmptyEnumerableException(string enumerableName)
        : base(message: $"{enumerableName} empty enumerable.")
    {
    }
}