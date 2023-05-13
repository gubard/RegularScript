using System.Linq;
using System.Windows.Input;
using AutoMapper;
using Avalonia.Collections;
using ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Interfaces;

namespace RegularScript.Ui.ViewModels;

public class ScriptsViewModel : ViewModelBase
{
    private LanguageNotify? selectedLanguage;

    [Inject] public IMapper? Mapper { get; set; }
    [Inject] public ILanguageService? LanguageService { get; set; }
    [Inject] public IScriptService? ScriptService { get; set; }

    public AvaloniaList<ScriptNodeNotify> Scripts { get; }
    public AvaloniaList<LanguageNotify> Languages { get; }
    public ICommand InitializedCommand { get; }

    public LanguageNotify? SelectedLanguage
    {
        get => selectedLanguage;
        set => this.RaiseAndSetIfChanged(ref selectedLanguage, value);
    }

    public ScriptsViewModel()
    {
        Languages = new();
        Scripts = new();

        InitializedCommand = ReactiveCommand.Create(async () =>
        {
            var languages = await LanguageService.ThrowIfNull().GetSupportedAsync();
            Languages.Clear();
            Languages.AddRange(languages.Select(x => Mapper.ThrowIfNull().Map<LanguageNotify>(x)));
            SelectedLanguage = Languages.First();
        });
    }
}