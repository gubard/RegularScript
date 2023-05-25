using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RegularScript.Ui.Views;

public partial class AddScriptView : UserControl
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