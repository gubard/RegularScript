using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RegularScript.Core.Common.Extensions;
using RegularScript.Db.Contexts;
using RegularScript.Db.Entities;
using RegularScript.Service.Interfaces;
using RegularScript.Service.Models;

namespace RegularScript.Service.Services;

public class ScriptRepository : IScriptRepository
{
    private readonly RegularScriptDbContext dbContext;
    private readonly IOptions<ScriptRepositoryOptions> options;

    public ScriptRepository(RegularScriptDbContext dbContext, IOptions<ScriptRepositoryOptions> options)
    {
        this.dbContext = dbContext;
        this.options = options;
    }

    public async Task<IEnumerable<Script>> GetRootScriptsAsync(Guid languageId)
    {
        var scriptsDb = from script in dbContext.Set<ScriptDb>().Where(x => x.ParentId == null)
            join scriptLocalization in dbContext.Set<ScriptLocalizationDb>().Where(x => x.LanguageId == languageId)
                on script.Id equals scriptLocalization.ScriptId into scriptLocalizations
            from scriptLocalization in scriptLocalizations.DefaultIfEmpty()
            join defaultScriptLocalization in dbContext.Set<ScriptLocalizationDb>()
                on script.Id equals defaultScriptLocalization.ScriptId into defaultScriptLocalizations
            from defaultScriptLocalization in defaultScriptLocalizations.DefaultIfEmpty()
            join language in dbContext.Set<LanguageDb>().Where(x => x.CodeIso3 == options.Value.DefaultLanguageCodeIso3)
                on defaultScriptLocalization.LanguageId equals language.Id
            select new
            {
                Id = script.Id,
                Name = scriptLocalization.Name,
                DefaultName = defaultScriptLocalization.Name,
                Description = scriptLocalization.Description,
                DefaultDescription = scriptLocalization.Description,
            };

        var scripts = await scriptsDb.ToArrayAsync();
        var result = new List<Script>();

        foreach (var item in scripts)
        {
            var script = new Script
            {
                Description = item.Description.IsNullOrWhiteSpace() ? item.DefaultDescription : item.Description,
                Id = item.Id,
                Name = item.Name.IsNullOrWhiteSpace() ? item.DefaultName : item.Name,
            };

            result.Add(script);
        }

        return result;
    }
}