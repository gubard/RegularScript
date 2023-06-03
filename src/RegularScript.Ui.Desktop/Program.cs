using System;
using Avalonia;
using Avalonia.ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Graph.Extensions;
using RegularScript.Core.Graph.Services;
using RegularScript.Core.ModularSystem.Extensions;
using RegularScript.Core.ModularSystem.Interfaces;
using RegularScript.Core.ModularSystem.Services;
using RegularScript.Ui.Desktop.Modules;

namespace RegularScript.Ui.Desktop;

internal class Program
{
    private static IModule? module;

    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp()
           .StartWithClassicDesktopLifetime(args);
    }

    private static void InitModules()
    {
        var builder = new TreeBuilder<Guid, IModule>().SetRoot(
            new TreeNodeBuilder<Guid, IModule>()
               .SetKey(DesktopModule.IdValue)
               .SetValue(new DesktopModule())
        );

        var moduleTree = new ModuleTree(builder.Build());
        module = moduleTree;
        moduleTree.SetupModule();
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        InitModules();

        return AppBuilder.Configure(() => module.ThrowIfNull().GetObject<Application>())
            .UsePlatformDetect()
            .LogToTrace()
            .UseReactiveUI();
    }
}