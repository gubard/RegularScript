using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using RegularScript.Model;

namespace RegularScript.Interfaces;

public interface IScriptService
{
    Task<IEnumerable<ScriptInfo>> GetRootScriptsAsync();
    Task<ScriptInfo> GetScriptAsync(Guid id);
    Task<IEnumerable<ScriptInfo>> GetChildrenAsync(Guid id);
}