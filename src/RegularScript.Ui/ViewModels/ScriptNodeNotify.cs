using Avalonia.Collections;
using ReactiveUI;

namespace RegularScript.Ui.ViewModels;

public class ScriptNodeNotify : ViewModelBase
{
    private string? name;

    public AvaloniaList<ScriptNodeNotify> Scripts { get; }

    public string? Name
    {
        get => name;
        set => this.RaiseAndSetIfChanged(ref name, value);
    }

    public ScriptNodeNotify()
    {
        Scripts = new ();
    }
}