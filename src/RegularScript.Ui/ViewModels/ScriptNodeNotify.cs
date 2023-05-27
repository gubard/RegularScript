using System;
using Avalonia.Collections;
using ReactiveUI;

namespace RegularScript.Ui.ViewModels;

public class ScriptNodeNotify : ViewModelBase
{
    private string? name;
    private Guid id;
    private string description;

    public ScriptNodeNotify()
    {
        Scripts = new AvaloniaList<ScriptNodeNotify>();
    }

    public AvaloniaList<ScriptNodeNotify> Scripts { get; }

    public Guid Id
    {
        get => id;
        set => this.RaiseAndSetIfChanged(ref id, value);
    }

    public string Description
    {
        get => description;
        set => this.RaiseAndSetIfChanged(ref description, value);
    }

    public string? Name
    {
        get => name;
        set => this.RaiseAndSetIfChanged(ref name, value);
    }
}