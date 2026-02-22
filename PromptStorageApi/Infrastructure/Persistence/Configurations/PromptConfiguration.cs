using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Infrastructure.Persistence.Configurations;

public sealed class PromptConfiguration : IEntityTypeConfiguration<Prompt>
{
    public void Configure(EntityTypeBuilder<Prompt> builder)
    {
        builder.ToTable("Prompt");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(p => p.Description)
               .HasMaxLength(1000);

        builder.Property(p => p.Body)
               .IsRequired()
               .HasColumnType("nvarchar(max)");

        builder.HasOne(p => p.Scene)
               .WithMany(s => s.Prompts)
               .HasForeignKey(p => p.SceneId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.AIGenerator)
               .WithMany(g => g.Prompts)
               .HasForeignKey(p => p.AIGeneratorId)
               .OnDelete(DeleteBehavior.Restrict);    

        builder.HasIndex(p => p.Title);
        builder.HasIndex(p => p.SceneId);
        builder.HasIndex(p => p.AIGeneratorId);
        builder.HasIndex(p => p.CreatedAtUtc);   
    }
}

