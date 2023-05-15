using System.Collections.Generic;
using System.Threading.Tasks;
using RegularScript.Db.Entities;

namespace RegularScript.Service.Interfaces;

public interface ILanguageRepository
{
    Task<IEnumerable<LanguageDb>> GetAllAsync();
    Task<IEnumerable<LanguageDb>> GetSupportedAsync();
}