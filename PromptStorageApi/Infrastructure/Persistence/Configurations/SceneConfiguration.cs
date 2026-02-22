using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Infrastructure.Persistence.Configurations;

public sealed class SceneConfiguration : IEntityTypeConfiguration<Scene>
{
    public void Configure(EntityTypeBuilder<Scene> builder)
    {
        builder.ToTable("Scene");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Title)
               .IsRequired()
               .HasMaxLength(120);

        builder.Property(s => s.Description)
               .HasMaxLength(1000);

        builder.HasOne(s => s.Performance)
               .WithMany(p => p.Scenes)
               .HasForeignKey(s => s.PerformanceId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(s => s.Title);
        builder.HasIndex(s => s.CreatedAtUtc);
    }
}