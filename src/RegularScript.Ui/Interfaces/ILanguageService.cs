using System.Collections.Generic;
using System.Threading.Tasks;
using RegularScript.Ui.Models;

namespace RegularScript.Ui.Interfaces;

public interface ILanguageService
{
    Task<IEnumerable<Language>> GetAllAsync();
    Task<IEnumerable<Language>> GetSupportedAsync();
}