using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RegularScript.Ui.Model;

namespace RegularScript.Ui.Interfaces;

public interface IScriptService
{
    Task<IEnumerable<ScriptInfo>> GetRootScriptsAsync();
    Task<ScriptInfo> GetScriptAsync(Guid id);
    Task<IEnumerable<ScriptInfo>> GetChildrenAsync(Guid id);
}