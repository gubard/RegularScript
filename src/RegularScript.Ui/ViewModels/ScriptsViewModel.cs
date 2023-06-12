using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using Avalonia.Collections;
using ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Extension;
using RegularScript.Ui.Interfaces;

namespace RegularScript.Ui.ViewModels;

public class ScriptsViewModel : RegularScriptViewModel, IRoutableViewModel, ISelectableLanguage
{
    private LanguageNotify? selectedLanguage;
    private ScriptNodeNotify? selectedScript;

    public ScriptsViewModel()
    {
        Languages = new();
        Scripts = new();
        var selectedLanguageChangedCommand = CreateCommandFromTask<LanguageNotify?>(OnSelectedLanguageChanged);
        InitializedCommand = CreateCommandFromTask(InitializedAsync);
        AddRootScriptCommand = CreateCommand(AddRootScript);
        AddScriptCommand = CreateCommand<ScriptNodeNotify>(AddScript);
        this.WhenAnyValue(x => x.SelectedLanguage).InvokeCommand(selectedLanguageChangedCommand);
    }

    [Inject]
    public required IMapper Mapper { get; init; }

    [Inject]
    public required ILanguageService LanguageService { get; init; }

    [Inject]
    public required IScriptService ScriptService { get; init; }

    [Inject]
    public required IViewState ViewState { get; init; }

    public IScreen? HostScreen => null;

    public AvaloniaList<ScriptNodeNotify> Scripts { get; }
    public AvaloniaList<LanguageNotify> Languages { get; }
    public ICommand InitializedCommand { get; }
    public ICommand AddRootScriptCommand { get; }
    public ICommand AddScriptCommand { get; }
    public string? UrlPathSegment => "script";

    public ScriptNodeNotify? SelectedScript
    {
        get => selectedScript;
        set =>  this.RaiseAndSetIfChanged(ref selectedScript, value);
    }

    public LanguageNotify? SelectedLanguage
    {
        get => selectedLanguage;
        set => this.RaiseAndSetIfChanged(ref selectedLanguage, value);
    }

    private async Task OnSelectedLanguageChanged(LanguageNotify? newLanguage)
    {
        if (newLanguage is null)
        {
            return;
        }

        var scripts = await ScriptService.ThrowIfNull().GetRootScriptsAsync(newLanguage.Id);
        Scripts.Clear();
        Scripts.AddRange(scripts.Select(x => Mapper.Map<ScriptNodeNotify>(x)));
    }

    private Task InitializedAsync()
    {
        ViewState.CurrentView = GetType();

        return this.UpdateLanguagesAsync(LanguageService, Mapper);
    }

    private void AddRootScript()
    {
        Navigator.NavigateTo<AddScriptViewModel>(viewModel => viewModel.SelectedLanguage = SelectedLanguage);
    }
    
    private void AddScript(ScriptNodeNotify parent)
    {
        Navigator.NavigateTo<AddScriptViewModel>(viewModel =>
            {
                viewModel.SelectedLanguage = SelectedLanguage;
                viewModel.Parent = parent;
            }
        );
    }
}