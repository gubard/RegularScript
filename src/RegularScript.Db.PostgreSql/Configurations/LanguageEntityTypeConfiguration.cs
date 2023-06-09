﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegularScript.Db.Entities;

namespace RegularScript.Db.PostgreSql.Configurations;

public class LanguageEntityTypeConfiguration : IEntityTypeConfiguration<LanguageDb>
{
    public void Configure(EntityTypeBuilder<LanguageDb> builder)
    {
        builder.ToTable("languages");
        builder.HasKey(x => x.Id);
        builder.HasIndex(x => x.Name).IsUnique();
        builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
        builder.HasIndex(x => x.CodeIso3).IsUnique();
        builder.Property(x => x.CodeIso3).HasMaxLength(3).IsRequired();
    }
}