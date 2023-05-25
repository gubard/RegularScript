using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Core.DependencyInjection.Interfaces;
using RegularScript.Core.DependencyInjection.Extensions;

namespace RegularScript.Ui.ViewModels;

public class RegularScriptViewModel : ViewModelBase
{
    [Inject]
    public required RoutingState Router { get; init; }

    [Inject]
    public required IResolver Resolver { get; init; }

    protected ICommand CreateCommand(Func<Task> execute)
    {
        var command = ReactiveCommand.Create(
            async () =>
            {
                try
                {
                    await execute.Invoke();
                }
                catch (Exception e)
                {
                    var errorViewModel = Resolver.Resolve<ErrorViewModel>();
                    errorViewModel.Text = e.ToString();
                    Router.Navigate.Execute(errorViewModel);
                }
            });

        return command;
    }
}