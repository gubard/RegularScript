using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegularScript.Db.Entities;

namespace RegularScript.Db.PostgreSql.Configurations;

public class ScriptEntityTypeConfiguration : IEntityTypeConfiguration<Script>
{
    public void Configure(EntityTypeBuilder<Script> builder)
    {
        builder.ToTable(name: "scripts");
        builder.HasKey(keyExpression: x => x.Id);

        builder.HasOne(navigationExpression: x => x.Parent)
           .WithOne()
           .HasForeignKey<Script>(foreignKeyExpression: x => x.ParentId);
    }
}