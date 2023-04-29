using System;
using Avalonia;
using Avalonia.Styling;
using ReactiveUI;

namespace RegularScript.Ui.ViewModels;

public class MainHeaderViewModel : ViewModelBase
{
    private bool isDarkTheme;

    public bool IsDarkTheme
    {
        get => isDarkTheme;
        set => this.RaiseAndSetIfChanged(ref isDarkTheme, value);
    }

    public MainHeaderViewModel()
    {
        this.WhenAnyValue(property1: x => x.IsDarkTheme)
           .Subscribe(
                onNext: x =>
                {
                    var application = Application.Current;

                    if (application is null)
                    {
                        return;
                    }

                    application.RequestedThemeVariant = x ? ThemeVariant.Dark : ThemeVariant.Light;
                });
    }
}