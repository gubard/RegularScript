using Microsoft.EntityFrameworkCore;

namespace RegularScript.Db.Contexts;

public class RegularScriptDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var assemblies  = AppDomain.CurrentDomain.GetAssemblies();

        foreach (var assembly in assemblies)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}