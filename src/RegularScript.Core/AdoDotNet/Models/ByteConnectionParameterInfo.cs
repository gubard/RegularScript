﻿using System.Collections.Generic;

namespace RegularScript.Core.AdoDotNet.Models;

public record ByteConnectionParameterInfo : ConnectionParameterInfo
{
    public ByteConnectionParameterInfo(
        string defaultAlias,
        IEnumerable<string> aliases,
        byte defaultValue
    )
        : base(defaultAlias, aliases, defaultValue.ToString()) { }
}
