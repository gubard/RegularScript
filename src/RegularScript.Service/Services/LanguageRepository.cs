using Microsoft.EntityFrameworkCore;
using RegularScript.Db.Contexts;
using RegularScript.Db.Entities;
using RegularScript.Service.Interfaces;

namespace RegularScript.Service.Services;

public class LanguageRepository : ILanguageRepository
{
    private readonly RegularScriptDbContext dbContext;

    public LanguageRepository(RegularScriptDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<LanguageDb>> GetAllAsync()
    {
        return await dbContext.Set<LanguageDb>().ToArrayAsync();
    }

    public async Task<IEnumerable<LanguageDb>> GetSupportedAsync()
    {
        return await dbContext.Set<LanguageDb>().Where(x => x.IsSupported).ToArrayAsync();
    }
}