using System;

namespace RegularScript.Core.Common.Exceptions;

public class ZeroException : Exception
{
    public ZeroException(string name) : base($"{name} can't be zero.")
    {
        Name = name;
    }

    public string Name { get; }
}