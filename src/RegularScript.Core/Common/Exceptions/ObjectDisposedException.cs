namespace RegularScript.Core.Common.Exceptions;

public class ObjectDisposedException<T> : ObjectDisposedException where T : notnull
{
    public T Value { get; }

    public ObjectDisposedException(T value) : base(objectName: value.ToString())
    {
        Value = value;
    }
}