using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularScript.Ui.Models;

namespace RegularScript.Ui.Interfaces;

public interface IScriptService
{
    Task<IEnumerable<Script>> GetRootScriptsAsync(Guid languageId);
    Task<Guid> AddRootScriptAsync(AddRootScriptParameters parameters);
    Task<Guid> AddScriptAsync(AddScriptParameters parameters);
}