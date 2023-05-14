using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegularScript.Db.Entities;

namespace RegularScript.Db.PostgreSql.Configurations;

public class ScriptEntityTypeConfiguration : IEntityTypeConfiguration<ScriptDb>
{
    public void Configure(EntityTypeBuilder<ScriptDb> builder)
    {
        builder.ToTable("scripts");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Parent)
            .WithOne()
            .HasForeignKey<ScriptDb>(x => x.ParentId);
    }
}