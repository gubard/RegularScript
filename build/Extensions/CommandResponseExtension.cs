using System;
using Ductus.FluentDocker.Model.Containers;
using Serilog;

namespace Extensions;

public static class CommandResponseExtension
{
    public static void LogAndCheck<T>(this CommandResponse<T> commandResponse)
    {
        if (!string.IsNullOrWhiteSpace(commandResponse.Error)) throw new Exception(commandResponse.Error);

        foreach (var log in commandResponse.Log) Log.Information("{Log}", log);
    }
}