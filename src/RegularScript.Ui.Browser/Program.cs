using System.Runtime.Versioning;
using Avalonia;
using Avalonia.Browser;
using Avalonia.ReactiveUI;

[assembly: SupportedOSPlatform(platformName: "browser")]

namespace RegularScript.Ui.Browser;

internal class Program
{
    private static void Main(string[] args)
    {
        BuildAvaloniaApp()
           .UseReactiveUI()
           .SetupBrowserApp(mainDivId: "out");
    }

    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>();
    }
}