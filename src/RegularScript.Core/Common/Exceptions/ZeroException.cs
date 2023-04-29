namespace RegularScript.Core.Common.Exceptions;

public class ZeroException : Exception
{
    public string Name { get; }

    public ZeroException(string name) : base(message: $"{name} can't be zero.")
    {
        Name = name;
    }
}