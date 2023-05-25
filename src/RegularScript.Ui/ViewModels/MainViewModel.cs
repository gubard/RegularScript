using System.Windows.Input;
using Avalonia.ReactiveUI;
using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Core.DependencyInjection.Interfaces;

namespace RegularScript.Ui.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        InitializedCommand =
            ReactiveCommand.Create(() =>
            {
                var scriptsViewModel = Resolver.Resolve<ScriptsViewModel>();
                RoutedViewHost.Router.Navigate.Execute(scriptsViewModel);
            });
    }

    [Inject]
    public required IResolver Resolver { get; init; }
    
    [Inject]
    public required RoutedViewHost RoutedViewHost { get; init; }

    public ICommand InitializedCommand { get; }
}