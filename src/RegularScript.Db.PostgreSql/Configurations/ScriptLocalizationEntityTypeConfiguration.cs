using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegularScript.Db.Entities;

namespace RegularScript.Db.PostgreSql.Configurations;

public class ScriptLocalizationEntityTypeConfiguration : IEntityTypeConfiguration<ScriptLocalizationDb>
{
    public void Configure(EntityTypeBuilder<ScriptLocalizationDb> builder)
    {
        builder.ToTable("script_localizations");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Language)
            .WithMany()
            .HasForeignKey(x => x.LanguageId);

        builder.HasOne(x => x.Script)
            .WithMany()
            .HasForeignKey(x => x.ScriptId);

        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
    }
}