using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RegularScript.Ui.Views;

public partial class ScriptsView : UserControl
{
    public ScriptsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}