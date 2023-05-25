using System.Windows.Input;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Ui.Interfaces;

namespace RegularScript.Ui.ViewModels;

public class MainViewModel : RegularScriptViewModel
{
    public MainViewModel()
    {
        InitializedCommand = CreateCommand(Initialized);
    }

    [Inject]
    public required RoutedViewHost RoutedViewHost { get; init; }

    public ICommand InitializedCommand { get; }

    private void Initialized()
    {
        Navigator.NavigateTo<ScriptsViewModel>();
    }
}