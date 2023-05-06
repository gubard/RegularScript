using Microsoft.EntityFrameworkCore;
using RegularScript.Db.PostgreSql.MigrationHelper;

var context = new MigrationRegularScriptDbContext();
await context.Database.MigrateAsync();