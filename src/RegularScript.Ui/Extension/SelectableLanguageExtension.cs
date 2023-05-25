using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RegularScript.Ui.Interfaces;
using RegularScript.Ui.ViewModels;

namespace RegularScript.Ui.Extension;

public static class SelectableLanguageExtension
{
    public static async Task UpdateLanguagesAsync<TSelectableLanguage>(
        this TSelectableLanguage selectableLanguage,
        ILanguageService languageService,
        IMapper mapper
    )
        where TSelectableLanguage : ISelectableLanguage
    {
        var oldId = selectableLanguage.SelectedLanguage?.Id;
        var languages = await languageService.GetSupportedAsync();
        selectableLanguage.Languages.Clear();
        selectableLanguage.Languages.AddRange(languages.Select(mapper.Map<LanguageNotify>));

        selectableLanguage.SelectedLanguage = selectableLanguage.Languages.FirstOrDefault(x => x.Id == oldId)
                                              ?? selectableLanguage.Languages.First();
    }
}