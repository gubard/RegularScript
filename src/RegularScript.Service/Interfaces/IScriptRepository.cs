using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularScript.Service.Models;

namespace RegularScript.Service.Interfaces;

public interface IScriptRepository
{
    Task<IEnumerable<Script>> GetRootScriptsAsync(Guid languageId);
    Task<Guid> AddRootScriptAsync(AddRootScriptParameters parameters);
    Task<Guid> AddScriptAsync(AddScriptParameters parameters);
}