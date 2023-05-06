using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RegularScript.Db.Contexts;

namespace RegularScript.Db.PostgreSql.MigrationHelper;

public class MigrationRegularScriptDbContext : RegularScriptDbContext
{
    private readonly IConfigurationRoot configuration;
    
    public MigrationRegularScriptDbContext()
    {
        configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(configuration["PostgreSql::ConnectionString"]);
    }
}