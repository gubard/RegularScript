using System.Collections.Generic;

namespace RegularScript.Core.AdoDotNet.Models;

public record StringConnectionParameterInfo : ConnectionParameterInfo
{
    public StringConnectionParameterInfo(
        string defaultAlias,
        IEnumerable<string> aliases,
        string defaultValue
    )
        : base(defaultAlias, aliases, defaultValue) { }
}
