using System;
using Avalonia;
using Avalonia.ReactiveUI;
using RegularScript.Core.Graph.Extensions;
using RegularScript.Core.Graph.Services;
using RegularScript.Core.ModularSystem.Extensions;
using RegularScript.Core.ModularSystem.Interfaces;
using RegularScript.Core.ModularSystem.Services;
using RegularScript.Ui.Modules;

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
               .SetKey(UiModule.IdValue)
               .SetValue(new UiModule())
        );

        module = new ModuleTree(builder.Build());
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        InitModules();

        return AppBuilder.Configure(() => module.GetObject<Application>())
           .UsePlatformDetect()
           .LogToTrace()
           .UseReactiveUI();
    }
}