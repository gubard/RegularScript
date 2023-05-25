using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;

namespace RegularScript.Ui.ViewModels;

public class ErrorViewModel : ViewModelBase, IRoutableViewModel
{
    private string text;

    public IScreen? HostScreen => null;

    [Inject]
    public required RoutingState RoutingState { get; init; }

    public string UrlPathSegment => "error";

    public string Text
    {
        get => text;
        set => this.RaiseAndSetIfChanged(ref text, value);
    }
}