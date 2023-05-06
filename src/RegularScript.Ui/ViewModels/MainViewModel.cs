using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Views;

namespace RegularScript.Ui.ViewModels;

public class MainViewModel : ViewModelBase
{
    [Inject]
    public RoutingState Router { get; set; }

    [Inject]
    public MainHeaderView HeaderView { get; set; }

    [Inject]
    public ScriptsView ScriptsView { get; set; }
}