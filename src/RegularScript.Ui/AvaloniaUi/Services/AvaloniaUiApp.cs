using System.Collections.Generic;
using System.Diagnostics;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Styling;
using DynamicData;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;

namespace RegularScript.Ui.AvaloniaUi.Services;

public class AvaloniaUiApp : Application
{
    public IResolver? Resolver { get; set; }

    public override void Initialize()
    {
        Resolver = Resolver.ThrowIfNull();
        var styles = Resolver.Resolve<IEnumerable<IStyle>>();
        var resourceProviders = Resolver.Resolve<IEnumerable<IResourceProvider>>();
        Styles.AddRange(styles);
        Resources.MergedDictionaries.AddRange(resourceProviders);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        base.OnFrameworkInitializationCompleted();
        Resolver = Resolver.ThrowIfNull();

        switch (ApplicationLifetime)
        {
            case IClassicDesktopStyleApplicationLifetime desktopLifetime:
            {
                desktopLifetime.MainWindow = Resolver.Resolve<Window>();

                break;
            }
            case ISingleViewApplicationLifetime singleViewLifetime:
            {
                singleViewLifetime.MainView = Resolver.Resolve<Control>();

                break;
            }
            default:
            {
                throw new UnreachableException();
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
}