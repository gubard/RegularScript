using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using RegularScript.Ui.ViewModels;

namespace RegularScript.Ui.Views;

public partial class AddScriptView : ReactiveUserControl<AddScriptViewModel>
{
    public AddScriptView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}