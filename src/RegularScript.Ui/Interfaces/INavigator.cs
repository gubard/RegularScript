using System;
using System.Reactive;
using ReactiveUI;

namespace RegularScript.Ui.Interfaces;

public interface INavigator
{
    ReactiveCommand<Unit, IRoutableViewModel?> NavigateBack { get; }

    IObservable<IRoutableViewModel> NavigateTo<TViewModel>(TViewModel parameter) where TViewModel : IRoutableViewModel;
    IObservable<IRoutableViewModel> NavigateTo(Type type);
    
    IObservable<IRoutableViewModel> NavigateTo<TViewModel>(Action<TViewModel>? setup = null)
        where TViewModel : IRoutableViewModel;
}