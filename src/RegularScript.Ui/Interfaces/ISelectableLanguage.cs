using Avalonia.Collections;
using RegularScript.Ui.ViewModels;

namespace RegularScript.Ui.Interfaces;

public interface ISelectableLanguage
{
    LanguageNotify? SelectedLanguage { get; set; }
    AvaloniaList<LanguageNotify> Languages { get; }
}