using System;
using ReactiveUI;

namespace RegularScript.Ui.ViewModels;

public class LanguageNotify : ViewModelBase
{
    private Guid id;
    private string? codeIso3;
    private string? name;

    public Guid Id
    {
        get => id;
        set => this.RaiseAndSetIfChanged(ref id, value);
    }

    public string? CodeIso3
    {
        get => codeIso3;
        set => this.RaiseAndSetIfChanged(ref codeIso3, value);
    }

    public string? Name
    {
        get => name;
        set => this.RaiseAndSetIfChanged(ref name, value);
    }
}