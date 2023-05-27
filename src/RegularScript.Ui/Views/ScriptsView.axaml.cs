using Avalonia.ReactiveUI;
using RegularScript.Ui.ViewModels;

namespace RegularScript.Ui.Views;

public partial class ScriptsView : ReactiveUserControl<ScriptsViewModel>
{
    public ScriptsView()
    {
        InitializeComponent();
    }
}