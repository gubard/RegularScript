using System;
using Avalonia;
using Avalonia.Styling;
using ReactiveUI;

namespace RegularScript.Ui.ViewModels;

public class MainHeaderViewModel : ViewModelBase
{
    private bool isDarkTheme;

    public MainHeaderViewModel()
    {
        this.WhenAnyValue(x => x.IsDarkTheme)
            .Subscribe(
                x =>
                {
                    var application = Application.Current;

                    if (application is null) return;

                    application.RequestedThemeVariant = x ? ThemeVariant.Dark : ThemeVariant.Light;
                });
    }

    public bool IsDarkTheme
    {
        get => isDarkTheme;
        set => this.RaiseAndSetIfChanged(ref isDarkTheme, value);
    }
}