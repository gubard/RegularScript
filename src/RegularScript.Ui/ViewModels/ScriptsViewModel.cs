using Avalonia.Collections;

namespace RegularScript.Ui.ViewModels;

public class ScriptsViewModel : ViewModelBase
{
    public AvaloniaList<ScriptNodeNotify> Scripts { get; }

    public ScriptsViewModel()
    {
        Scripts = new ();
    }
}