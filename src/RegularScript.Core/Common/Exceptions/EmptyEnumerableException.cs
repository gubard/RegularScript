using System;

namespace RegularScript.Core.Common.Exceptions;

public class EmptyEnumerableException : Exception
{
    public EmptyEnumerableException(string enumerableName)
        : base($"{enumerableName} empty enumerable.")
    {
    }
}