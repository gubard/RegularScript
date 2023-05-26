using System;
using ReactiveUI;
using RegularScript.Core.Common.Interfaces;
using RegularScript.Core.DependencyInjection.Attributes;

namespace RegularScript.Ui.ViewModels;

public class ErrorViewModel : ViewModelBase, IRoutableViewModel
{
    private Exception? exception;
    private object? content;

    public ErrorViewModel()
    {
        this.WhenAnyValue(x => x.Exception).Subscribe(OnExceptionChanged);
    }

    public IScreen? HostScreen => null;
    public string UrlPathSegment => "error";

    [Inject]
    public required RoutingState RoutingState { get; init; }

    [Inject]
    public required IHumanizing<Exception, object> Humanizing { get; init; }

    public object? Content
    {
        get => content;
        set => this.RaiseAndSetIfChanged(ref content, value);
    }

    public Exception? Exception
    {
        get => exception;
        set => this.RaiseAndSetIfChanged(ref exception, value);
    }

    private void OnExceptionChanged(Exception? newException)
    {
        Content = newException is null ? null : Humanizing.Humanize(newException);
    }
}