using Avalonia.Collections;

using ReactiveUI;

namespace RegularScript.ViewModels;

public class ScriptNodeNotify : ViewModelBase
{
    private string name;

    public ScriptNodeNotify()
    {
        Scripts = new ();
    }

    public AvaloniaList<ScriptNodeNotify> Scripts { get; }

    public string Name
    {
        get => name;
        set => this.RaiseAndSetIfChanged(ref name, value);
    }
}