using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegularScript.Db.Entities;

namespace RegularScript.Db.PostgreSql.Configurations;

public class ScriptLocalizationEntityTypeConfiguration : IEntityTypeConfiguration<ScriptLocalizationDb>
{
    public void Configure(EntityTypeBuilder<ScriptLocalizationDb> builder)
    {
        builder.ToTable(name: "script_localizations");
        builder.HasKey(keyExpression: x => x.Id);

        builder.HasOne(navigationExpression: x => x.Language)
           .WithMany()
           .HasForeignKey(foreignKeyExpression: x => x.LanguageId);

        builder.HasOne(navigationExpression: x => x.Script)
           .WithMany()
           .HasForeignKey(foreignKeyExpression: x => x.ScriptId);

        builder.Property(propertyExpression: x => x.Name).HasMaxLength(maxLength: 255).IsRequired();
    }
}