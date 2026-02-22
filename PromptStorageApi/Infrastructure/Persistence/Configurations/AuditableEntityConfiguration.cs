using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromptStorageApi.Domain.Entities;
using PromptStorageApi.Domain.Common;

namespace PromptStorageApi.Infrastructure.Persistence.Configurations;

public abstract class AuditableEntityConfiguration<T>
        : IEntityTypeConfiguration<T>
        where T : AuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Property(x => x.RowVersion)
               .IsRowVersion();

        builder.Property(x => x.CreatedAtUtc).IsRequired();
        builder.Property(x => x.UpdatedAtUtc).IsRequired();
    }
}
