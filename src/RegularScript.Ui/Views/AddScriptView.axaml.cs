using Avalonia.ReactiveUI;
using RegularScript.Ui.ViewModels;

namespace RegularScript.Ui.Views;

public partial class AddScriptView : ReactiveUserControl<AddScriptViewModel>
{
    public AddScriptView()
    {
        InitializeComponent();
    }
}