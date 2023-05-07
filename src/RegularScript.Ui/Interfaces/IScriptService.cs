using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularScript.Ui.Models;

namespace RegularScript.Ui.Interfaces;

public interface IScriptService
{
    Task<IEnumerable<ScriptInfo>> GetRootScriptsAsync();
    Task<ScriptInfo> GetScriptAsync(Guid id);
    Task<IEnumerable<ScriptInfo>> GetChildrenAsync(Guid id);
}