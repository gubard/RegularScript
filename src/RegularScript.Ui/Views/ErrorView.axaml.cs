using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using RegularScript.Ui.ViewModels;

namespace RegularScript.Ui.Views;

public partial class ErrorView : ReactiveUserControl<ErrorViewModel>
{
    public ErrorView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}