namespace RegularScript.Core.Common.Interfaces;

public interface IIdentifier<out TKey>
{
    public TKey Key { get; }
}