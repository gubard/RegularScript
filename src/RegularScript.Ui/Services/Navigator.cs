using System;
using System.Reactive;
using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Extensions;
using RegularScript.Ui.Interfaces;

namespace RegularScript.Ui.Services;

public class Navigator : INavigator
{
    [Inject]
    public required RoutingState RoutingState { get; init; }

    [Inject]
    public required IResolver Resolver { get; init; }
    
    public ReactiveCommand<Unit, IRoutableViewModel?> NavigateBack => RoutingState.NavigateBack;

    public IObservable<IRoutableViewModel> NavigateTo(Type type)
    {
        var viewModel = (IRoutableViewModel)Resolver.Resolve(type);

        return RoutingState.Navigate.Execute(viewModel);
    }

    public IObservable<IRoutableViewModel> NavigateTo<TViewModel>(Action<TViewModel>? setup = null) where TViewModel : IRoutableViewModel
    {
        var viewModel = Resolver.Resolve<TViewModel>();

        if (setup is null)
        {
            return RoutingState.Navigate.Execute(viewModel);
        }
        
        setup.Invoke(viewModel);

        return RoutingState.Navigate.Execute(viewModel);
    }

    public IObservable<IRoutableViewModel> NavigateTo<TViewModel>(TViewModel parameter)
        where TViewModel : IRoutableViewModel
    {
        return RoutingState.Navigate.Execute(parameter);
    }
}