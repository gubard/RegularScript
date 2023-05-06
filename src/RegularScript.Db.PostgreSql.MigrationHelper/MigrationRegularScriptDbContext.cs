using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RegularScript.Db.Contexts;

namespace RegularScript.Db.PostgreSql.MigrationHelper;

public class MigrationRegularScriptDbContext : RegularScriptDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseNpgsql(configuration["PostgreSql::ConnectionString"]);
    }
}