using Avalonia;
using Avalonia.iOS;
using Avalonia.ReactiveUI;
using Foundation;

namespace RegularScript.Ui.iOS;

// The UIApplicationDelegate for the application. This class is responsible for launching the 
// User Interface of the application, as well as listening (and optionally responding) to 
// application events from iOS.
[Register(name: "AppDelegate")]
public class AppDelegate : AvaloniaAppDelegate<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        return builder.UseReactiveUI();
    }
}