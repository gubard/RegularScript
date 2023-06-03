using System;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Browser;
using Avalonia.ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.Graph.Extensions;
using RegularScript.Core.Graph.Services;
using RegularScript.Core.ModularSystem.Extensions;
using RegularScript.Core.ModularSystem.Interfaces;
using RegularScript.Core.ModularSystem.Services;
using RegularScript.Ui.Browser.Modules;

[assembly: SupportedOSPlatform("browser")]

namespace RegularScript.Ui.Browser;

internal class Program
{
    private static IModule? module;

    private static async Task Main(string[] args)
    {
       await BuildAvaloniaApp()
            .UseReactiveUI()
            .StartBrowserAppAsync("out");
    }

    private static void InitModules()
    {
        var builder = new TreeBuilder<Guid, IModule>().SetRoot(
            new TreeNodeBuilder<Guid, IModule>()
                .SetKey(BrowserModule.IdValue)
                .SetValue(new BrowserModule())
        );

        var moduleTree = new ModuleTree(builder.Build());
        moduleTree.SetupModule();
        module = moduleTree;
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        InitModules();

        return AppBuilder.Configure(() => module.ThrowIfNull().GetObject<Application>()).UseReactiveUI();
    }
}