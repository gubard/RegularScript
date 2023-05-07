using System;
using System.Linq;
using System.Windows.Input;
using AutoMapper;
using Avalonia.Collections;
using ReactiveUI;
using RegularScript.Core.DependencyInjection.Attributes;
using RegularScript.Ui.Interfaces;

namespace RegularScript.Ui.ViewModels;

public class ScriptsViewModel : ViewModelBase
{
    [Inject] public IMapper Mapper { get; set; }
    [Inject] public ILanguageService LanguageService { get; set; }

    public AvaloniaList<ScriptNodeNotify> Scripts { get; }
    public AvaloniaList<LanguageNotify> Languages { get; }
    public ICommand InitializedCommand { get; }

    public ScriptsViewModel()
    {
        Languages = new();
        Scripts = new();
        
        InitializedCommand = ReactiveCommand.Create( async () =>
        {
            try
            {
                var languages  = await LanguageService.GetAllAsync();
                Languages.Clear();
                Languages.AddRange(languages.Select(x => Mapper.Map<LanguageNotify>(x)));
            }
            catch (Exception e)
            {
                throw;
            }
        });
    }
}