using System;
using System.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Interfaces;

namespace RegularScript.Ui.ViewModels;

public class RegularScriptViewModel : ViewModelBase
{
    [Inject]
    public required INavigator Navigator { get; init; }
    
    protected ICommand CreateCommand(Action action)
    {
        var command = ReactiveCommand.Create(action);
        SetupCommand(command);

        return command;
    }

    protected ICommand CreateCommandFromTask(Func<Task> execute)
    {
        var command = ReactiveCommand.CreateFromTask(execute);
        SetupCommand(command);

        return command;
    }

    protected ICommand CreateCommandFromTask<TParam>(Func<TParam, Task> execute)
    {
        var command = ReactiveCommand.CreateFromTask(execute);
        SetupCommand(command);

        return command;
    }

    private void SetupCommand<TParam, TResult>(ReactiveCommand<TParam, TResult> command)
    {
        command.ThrownExceptions.Subscribe(
            exception => Navigator.NavigateTo<ErrorViewModel>(viewModel => viewModel.Text = exception.ToString())
        );
    }
}