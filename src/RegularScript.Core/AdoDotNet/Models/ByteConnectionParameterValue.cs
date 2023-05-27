namespace RegularScript.Core.AdoDotNet.Models;

public record ByteConnectionParameterValue(byte ByteVvalue)
    : ConnectionParameterValue(ByteVvalue.ToString());
