using System.Reflection;

namespace RegularScript.Core.Common.Models;

public readonly record struct TypeIdentifier
{
    private readonly object Identifier;

    public TypeIdentifier(IReflect type)
    {
        Identifier = type.UnderlyingSystemType;
    }

    public static implicit operator TypeIdentifier(Type type)
    {
        return new (type);
    }
}