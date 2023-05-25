using System;
using System.Windows.Input;
using Avalonia.ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;

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
        try
        {
            Navigator.NavigateTo<ScriptsViewModel>();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}