using RegularScript.Core.Common.Extensions;

namespace RegularScript.Core.Common.Exceptions;

public class TypeInvalidCastException : InvalidCastException
{
    public Type CurrentType { get; }
    public IEnumerable<Type> ExpectedTypes { get; }

    public TypeInvalidCastException(Type expectedType, Type currentType)
        : base(message: CreateMessage(expectedType, currentType))
    {
        CurrentType = currentType;

        ExpectedTypes = new[]
        {
            expectedType,
        };
    }

    public TypeInvalidCastException(Type currentType, params Type[] expectedTypes)
        : base(message: CreateMessage(expectedTypes, currentType))
    {
        CurrentType = currentType;
        ExpectedTypes = expectedTypes.ThrowIfNullOrEmpty().ToArray();
    }

    public TypeInvalidCastException(Type currentType, IEnumerable<Type> expectedTypes)
        : this(currentType, expectedTypes: expectedTypes.ToArray())
    {
    }

    private static string CreateMessage(Type expectedType, Type currentType)
    {
        return $"Expected type \"{expectedType}\" actual type \"{currentType}\".";
    }

    private static string CreateMessage(IEnumerable<Type> expectedTypes, Type currentType)
    {
        return $"Expected type \"{expectedTypes.JoinString(separator: "\", \"")}\" actual type \"{currentType}\".";
    }
}