using System;
using System.Windows.Input;
using Avalonia.ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Views;

namespace RegularScript.Ui.ViewModels;

public class MainViewModel : RegularScriptViewModel
{
    public MainViewModel()
    {
        InitializedCommand = CreateCommand(Initialized);
    }

    [Inject]
    public required RoutedViewHost RoutedViewHost { get; init; }

    [Inject]
    public required MainHeaderView MainHeaderView { get; init; }

    public ICommand InitializedCommand { get; }

    private void Initialized()
    {
        Navigator.NavigateTo<ScriptsViewModel>();
    }
}