using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using RegularScript.Db.Entities;

namespace RegularScript.Db.PostgreSql.Configurations;

public class ScriptEntityTypeConfiguration : IEntityTypeConfiguration<Script>
{
    public void Configure(EntityTypeBuilder<Script> builder)
    {
        builder.ToTable("scripts");
        builder.HasKey(x => x.Id);
        builder.HasOne(x => x.Parent).WithOne().HasForeignKey<Script>(x => x.ParentId);
    }
}