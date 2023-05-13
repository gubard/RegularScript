using System.Linq;
using Ductus.FluentDocker.Commands;
using Ductus.FluentDocker.Services;
using JetBrains.Annotations;
using Serilog;

namespace Extensions;

public static class HostServiceExtension
{
    [CanBeNull]
    public static string GetContainerId(this IHostService hostService, string name)
    {
        var psCommandResponse = hostService.Host.Ps($"--all --filter name={name}");
        psCommandResponse.LogAndCheck();
        Log.Information("List {Name}", name);
        var result = psCommandResponse.Data.SingleOrDefault();

        return result;
    }

    public static void StopContainer(this IHostService hostService, string containerId, string name)
    {
        var stopCommandResponse = hostService.Host.Stop(containerId);
        stopCommandResponse.LogAndCheck();
        Log.Information("Stop {Name}", name);
    }

    public static void RemoveContainer(this IHostService hostService, string containerId, string name)
    {
        var removeContainerCommandResponse = hostService.Host.RemoveContainer(containerId);
        removeContainerCommandResponse.LogAndCheck();
        Log.Information("Remove {Name}", name);
    }
}