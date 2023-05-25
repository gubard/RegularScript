using System.Threading.Tasks;
using System.Windows.Input;
using AutoMapper;
using Avalonia.Collections;
using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Extension;
using RegularScript.Ui.Interfaces;
using RegularScript.Ui.Models;

namespace RegularScript.Ui.ViewModels;

public class AddScriptViewModel : RegularScriptViewModel, IRoutableViewModel, ISelectableLanguage
{
    private LanguageNotify? selectedLanguage;
    private string name;
    private string description;

    public AddScriptViewModel()
    {
        Languages = new();
        name = string.Empty;
        description = string.Empty;
        InitializedCommand = CreateCommandFromTask(InitializedAsync);
        AddCommand = CreateCommandFromTask(AddAsync);
    }

    [Inject]
    public required IMapper Mapper { get; init; }

    [Inject]
    public required IScriptService ScriptService { get; init; }

    [Inject]
    public required ILanguageService LanguageService { get; init; }

    public ICommand InitializedCommand { get; }
    public ICommand AddCommand { get; }
    public string? UrlPathSegment => "add-script";
    public IScreen HostScreen => null;
    public AvaloniaList<LanguageNotify> Languages { get; }

    public LanguageNotify? SelectedLanguage
    {
        get => selectedLanguage;
        set => this.RaiseAndSetIfChanged(ref selectedLanguage, value);
    }

    public string Name
    {
        get => name;
        set => this.RaiseAndSetIfChanged(ref name, value);
    }

    public string Description
    {
        get => description;
        set => this.RaiseAndSetIfChanged(ref description, value);
    }

    private Task InitializedAsync()
    {
        return this.UpdateLanguagesAsync(LanguageService, Mapper);
    }

    private Task AddAsync()
    {
        var parameters = Mapper.Map<AddScriptParameters>(this);

        return ScriptService.AddScriptAsync(parameters);
    }
}