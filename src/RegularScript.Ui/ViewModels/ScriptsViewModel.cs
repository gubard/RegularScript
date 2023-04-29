using Avalonia.Collections;

namespace RegularScript.Ui.ViewModels;

public class ScriptsViewModel : ViewModelBase
{
    public ScriptsViewModel()
    {
        Scripts = new ();
    }

    public AvaloniaList<ScriptNodeNotify> Scripts { get; }
}