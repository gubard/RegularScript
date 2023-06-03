using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RegularScript.Db.Entities;

namespace RegularScript.Db.PostgreSql.Configurations;

public class IdempotentItemEntityTypeConfiguration : IEntityTypeConfiguration<IdempotentItemDb>
{
    public void Configure(EntityTypeBuilder<IdempotentItemDb> builder)
    {
        builder.ToTable("idempotent_items");
        builder.HasKey(x => x.Id);
    }
}