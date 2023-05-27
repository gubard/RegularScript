namespace RegularScript.Core.AdoDotNet.Models;

public record BooleanConnectionParameterValue(bool BooleanValue)
    : ConnectionParameterValue(BooleanValue.ToString());
