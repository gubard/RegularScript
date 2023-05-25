using System.Linq;
using System.Windows.Input;
using AutoMapper;
using Avalonia.Collections;
using ReactiveUI;
using RegularScript.Core.Common.Extensions;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Interfaces;

namespace RegularScript.Ui.ViewModels;

public class AddScriptViewModel : ViewModelBase
{
    private LanguageNotify? selectedLanguage;
    private string name;
    private string description;

    public AddScriptViewModel()
    {
        Languages = new ();
        name = string.Empty;
        description = string.Empty;
        InitializedCommand = ReactiveCommand.Create( async () =>
        {
            var languages = await LanguageService.ThrowIfNull().GetSupportedAsync();
            Languages.Clear();
            Languages.AddRange(languages.Select(x => Mapper.ThrowIfNull().Map<LanguageNotify>(x)));
            SelectedLanguage = Languages.First();
        });
    }

    [Inject]
    public IMapper? Mapper { get; set; }
    
    [Inject]
    public ILanguageService? LanguageService { get; set; }
    
    
    public ICommand InitializedCommand { get; }
    
    public AvaloniaList<LanguageNotify> Languages { get; }
    
    public LanguageNotify? SelectedLanguage
    {
        get => selectedLanguage;
        set => this.RaiseAndSetIfChanged(ref selectedLanguage, value);
    }

    public string Name
    {
        get => name;
        set =>  this.RaiseAndSetIfChanged(ref name, value);
    }

    public string Description
    {
        get => description;
        set =>  this.RaiseAndSetIfChanged(ref description, value);
    }
}