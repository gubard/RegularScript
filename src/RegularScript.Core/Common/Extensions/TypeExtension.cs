﻿namespace RegularScript.Core.Common.Extensions;

public static class TypeExtension
{
    public static bool IsClosure(this Type type)
    {
        if (type.ToString() == "System.Runtime.CompilerServices.Closure")
        {
            return true;
        }

        return false;
    }

    public static object? GetDefaultValue(this Type type)
    {
        if (type.IsValueType)
        {
            return Activator.CreateInstance(type);
        }

        return null;
    }

    public static bool IsEnumerable(this Type type)
    {
        if (!type.IsGenericType)
        {
            return false;
        }

        if (type.GenericTypeArguments.Length != 1)
        {
            return false;
        }

        var genericType = type.GetGenericTypeDefinition();

        if (genericType != typeof(IEnumerable<>))
        {
            return false;
        }

        return true;
    }
}