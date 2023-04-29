﻿using System;
using System.ComponentModel;
using System.Globalization;
using Avalonia;
using Avalonia.Data.Converters;
using RegularScript.Core.Common.Extensions;

namespace RegularScript.Ui.AvaloniaUi.Converters;

public class MinusToNumberConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is null ? targetType.GetDefaultValue() : value.ToString();
    }

    public object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (value is null)
        {
            return targetType.GetDefaultValue();
        }

        var str = value.ToString();

        switch (str)
        {
            case "-":
            {
                return targetType.GetDefaultValue();
            }
            case "":
            {
                return targetType.GetDefaultValue();
            }
            default:
            {
                var converter = TypeDescriptor.GetConverter(targetType);

                try
                {
                    return converter.ConvertFromInvariantString(text: str.ThrowIfNull());
                }
                catch
                {
                    return AvaloniaProperty.UnsetValue;
                }
            }
        }
    }
}