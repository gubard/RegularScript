using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegularScript.Db.Entities;

namespace RegularScript.Db.PostgreSql.Configurations;

public class LanguageEntityTypeConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.ToTable(name: "languages");
        builder.HasKey(keyExpression: x => x.Id);
        builder.HasIndex(indexExpression: x => x.Name).IsUnique();
        builder.Property(propertyExpression: x => x.Name).HasMaxLength(maxLength: 255).IsRequired();
        builder.HasIndex(indexExpression: x => x.CodeIso3).IsUnique();
        builder.Property(propertyExpression: x => x.CodeIso3).HasMaxLength(maxLength: 3).IsRequired();
    }
}