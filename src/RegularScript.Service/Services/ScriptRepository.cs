using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        var scriptsDb =
            from script in dbContext.Set<ScriptDb>().Where(x => x.ParentId == null)
            join scriptLocalization in dbContext.Set<ScriptLocalizationDb>().Where(x => x.LanguageId == languageId)
                on script.Id equals scriptLocalization.ScriptId into scriptLocalizations
            from scriptLocalization in scriptLocalizations.DefaultIfEmpty()
            join defaultScriptLocalization in dbContext.Set<ScriptLocalizationDb>()
                on script.Id equals defaultScriptLocalization.ScriptId into defaultScriptLocalizations
            from defaultScriptLocalization in defaultScriptLocalizations.DefaultIfEmpty()
            join language in dbContext.Set<LanguageDb>().Where(x => x.CodeIso3 == options.Value.DefaultLanguageCodeIso3)
                on defaultScriptLocalization.LanguageId equals language.Id into languages
            from language in languages.DefaultIfEmpty()
            select new
            {
                script.Id,
                scriptLocalization.Name,
                DefaultName = defaultScriptLocalization.Name,
                scriptLocalization.Description,
                DefaultDescription = scriptLocalization.Description
            };

        var scripts = await scriptsDb.ToArrayAsync();
        var result = new List<Script>();

        foreach (var item in scripts)
        {
            var script = new Script
            {
                Description = item.Description.IsNullOrWhiteSpace() ? item.DefaultDescription : item.Description,
                Id = item.Id,
                Name = item.Name.IsNullOrWhiteSpace() ? item.DefaultName : item.Name
            };

            result.Add(script);
        }

        return result;
    }

    public async Task<Guid> AddRootScriptAsync(AddRootScriptParameters parameters)
    {
        var newScript = await dbContext.Set<ScriptDb>().AddAsync(new ScriptDb());

        var scriptLocalizationDb = new ScriptLocalizationDb()
        {
            ScriptId = newScript.Entity.Id,
            Description = parameters.Description,
            Name = parameters.Name,
            LanguageId = parameters.LanguageId,
        };

        await dbContext.Set<ScriptLocalizationDb>().AddAsync(scriptLocalizationDb);
        await dbContext.SaveChangesAsync();

        return newScript.Entity.Id;
    }

    public async Task<Guid> AddScriptAsync(AddScriptParameters parameters)
    {
        var newScript = await dbContext.Set<ScriptDb>().AddAsync(new ScriptDb
        {
            ParentId = parameters.ParentId
        });

        var scriptLocalizationDb = new ScriptLocalizationDb()
        {
            ScriptId = newScript.Entity.Id,
            Description = parameters.Description,
            Name = parameters.Name,
            LanguageId = parameters.LanguageId,
        };

        await dbContext.Set<ScriptLocalizationDb>().AddAsync(scriptLocalizationDb);
        await dbContext.SaveChangesAsync();

        return newScript.Entity.Id;
    }
}