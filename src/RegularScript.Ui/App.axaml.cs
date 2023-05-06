using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Extensions;

namespace RegularScript.Ui;

public class App : Application
{
    [Inject]
    public IResolver Resolver { get; set; }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(obj: this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var resolver = Resolver.ThrowIfNull();

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = resolver.Resolve<Window>();
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = resolver.Resolve<Control>();
        }

        base.OnFrameworkInitializationCompleted();
    }
}