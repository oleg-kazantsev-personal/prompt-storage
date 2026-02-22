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

        builder.HasData(
            new AIGenerator(new Guid("11111111-1111-1111-1111-111111111111"))
            {
                Name = "OpenAI",
                WebsiteUrl = "https://openai.com",
                CreatedBy = "System",
                UpdatedBy = "System",   
                CreatedAtUtc = new DateTime(2024, 1, 1),
                UpdatedAtUtc = new DateTime(2024, 1, 1),
                IsDeleted = false
            },
            new AIGenerator(new Guid("22222222-2222-2222-2222-222222222222"))
            {
                Name = "Gemini",
                WebsiteUrl = "https://gemini.google.com",
                CreatedBy = "System",
                UpdatedBy = "System",   
                CreatedAtUtc = new DateTime(2024, 1, 1),
                UpdatedAtUtc = new DateTime(2024, 1, 1),
                IsDeleted = false
            }
        );
    }
}