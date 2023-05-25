using System;
using Avalonia;
using Avalonia.Styling;
using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Interfaces;

namespace RegularScript.Ui.ViewModels;

public class MainHeaderViewModel : ViewModelBase
{
    private bool isDarkTheme;

    public MainHeaderViewModel()
    {
        this.WhenAnyValue(x => x.IsDarkTheme)
            .Subscribe(OnIsDarkThemeChanged);
    }

    [Inject]
    public required INavigator Navigator { get; init; }

    public bool IsDarkTheme
    {
        get => isDarkTheme;
        set => this.RaiseAndSetIfChanged(ref isDarkTheme, value);
    }

    private void OnIsDarkThemeChanged(bool newIsDarkTheme)
    {
        var application = Application.Current;

        if (application is null)
        {
            return;
        }

        application.RequestedThemeVariant = newIsDarkTheme ? ThemeVariant.Dark : ThemeVariant.Light;
    }
}