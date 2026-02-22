using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Infrastructure.Persistence.Configurations;

public sealed class AIGeneratorConfiguration : AuditableEntityConfiguration<AIGenerator>
{
    public override void Configure(EntityTypeBuilder<AIGenerator> builder)
    {
        base.Configure(builder);

        builder.ToTable("AIGenerator");

        builder.HasKey(g => g.Id);

        builder.Property(g => g.Name)
               .IsRequired()
               .HasMaxLength(80);

        builder.Property(g => g.WebsiteUrl)
               .HasMaxLength(500);

        builder.HasIndex(g => g.Name);
    }
}