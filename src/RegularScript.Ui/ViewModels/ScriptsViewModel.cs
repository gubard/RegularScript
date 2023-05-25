using System.Linq;
using System.Windows.Input;
using AutoMapper;
using Avalonia.Collections;
using ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Interfaces;
using RegularScript.Ui.Models;

namespace RegularScript.Ui.ViewModels;

public class ScriptsViewModel : RegularScriptViewModel, IRoutableViewModel
{
    private LanguageNotify? selectedLanguage;

    public ScriptsViewModel()
    {
        Languages = new ();
        Scripts = new ();

        var selectedLanguageChangedCommand = ReactiveCommand.CreateFromTask<LanguageNotify?>(
            async selectedLanguage =>
            {
                if (selectedLanguage is null)
                {
                    return;
                }

                var scripts = await ScriptService.ThrowIfNull().GetRootScriptsAsync(selectedLanguage.Id);
                Scripts.Clear();
                Scripts.AddRange(scripts.Select(x => Mapper.ThrowIfNull().Map<ScriptNodeNotify>(x)));
            }
        );

        InitializedCommand = CreateCommand(
            async () =>
            {
                var languages = await LanguageService.ThrowIfNull().GetSupportedAsync();
                Languages.Clear();
                Languages.AddRange(languages.Select(x => Mapper.ThrowIfNull().Map<LanguageNotify>(x)));
                SelectedLanguage = Languages.First();
            });

        AddScriptCommand = ReactiveCommand.Create(
            async () =>
            {
                var parameters = Mapper.Map<AddScriptParameters>(this);
                await ScriptService.AddScriptAsync(parameters);
            });

        this.WhenAnyValue(x => x.SelectedLanguage).InvokeCommand(selectedLanguageChangedCommand);
    }

    [Inject]
    public required IMapper Mapper { get; init; }

    [Inject]
    public required ILanguageService LanguageService { get; init; }

    [Inject]
    public required IScriptService ScriptService { get; init; }
    
    public IScreen? HostScreen => null;

    public AvaloniaList<ScriptNodeNotify> Scripts { get; }
    public AvaloniaList<LanguageNotify> Languages { get; }
    public ICommand InitializedCommand { get; }
    public ICommand AddScriptCommand { get; }
    public string? UrlPathSegment => "script";

    public LanguageNotify? SelectedLanguage
    {
        get => selectedLanguage;
        set => this.RaiseAndSetIfChanged(ref selectedLanguage, value);
    }
}