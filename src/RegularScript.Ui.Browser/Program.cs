using System;
using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Browser;
using Avalonia.ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Graph.Extensions;
using RegularScript.Core.Graph.Services;
using RegularScript.Core.ModularSystem.Extensions;
using RegularScript.Core.ModularSystem.Interfaces;
using RegularScript.Core.ModularSystem.Services;
using RegularScript.Ui.Modules;

[assembly: SupportedOSPlatform("browser")]

namespace RegularScript.Ui.Browser;

internal class Program
{
    private static IModule? module;

    private static void Main(string[] args)
    {
        BuildAvaloniaApp()
            .UseReactiveUI()
            .SetupBrowserApp("out");
    }

    private static void InitModules()
    {
        var builder = new TreeBuilder<Guid, IModule>().SetRoot(
            new TreeNodeBuilder<Guid, IModule>()
                .SetKey(UiModule.IdValue)
                .SetValue(new UiModule())
        );

        module = new ModuleTree(builder.Build());
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        InitModules();

        return AppBuilder.Configure(() => module.ThrowIfNull().GetObject<Application>()).UseReactiveUI();
    }
}