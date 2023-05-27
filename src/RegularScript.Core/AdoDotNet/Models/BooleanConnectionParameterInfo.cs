﻿using System.Collections.Generic;

namespace RegularScript.Core.AdoDotNet.Models;

public record BooleanConnectionParameterInfo : ConnectionParameterInfo
{
    public bool DefaultBooleanValue { get; }

    public BooleanConnectionParameterInfo(
        string defaultAlias,
        IEnumerable<string> aliases,
        bool defaultValue
    )
        : base(defaultAlias, aliases, defaultValue.ToString())
    {
        DefaultBooleanValue = defaultValue;
    }
}
