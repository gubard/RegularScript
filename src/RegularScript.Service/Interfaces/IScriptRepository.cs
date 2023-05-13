using RegularScript.Service.Models;

namespace RegularScript.Service.Interfaces;

public interface IScriptRepository
{
    Task<IEnumerable<Script>> GetRootScriptsAsync(Guid languageId);
}