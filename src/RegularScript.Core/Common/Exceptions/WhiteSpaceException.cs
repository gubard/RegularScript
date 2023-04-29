namespace RegularScript.Core.Common.Exceptions;

public class WhiteSpaceException : Exception
{
    public string Name { get; }

    public WhiteSpaceException(string name) : base(message: $"{name} can't be white space.")
    {
        Name = name;
    }
}