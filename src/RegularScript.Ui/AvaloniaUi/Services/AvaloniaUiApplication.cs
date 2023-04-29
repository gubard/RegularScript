using System.Threading.Tasks;
using Avalonia;
using RegularScript.Core.Application.Interfaces;

namespace RegularScript.Ui.AvaloniaUi.Services;

public abstract class AvaloniaUiApplication : IApplication
{
    protected AppBuilder Builder { get; }

    protected AvaloniaUiApplication(AppBuilder builder)
    {
        Builder = builder;
    }

    public abstract void Run(string[] args);
    public abstract Task RunAsync(string[] args);
}