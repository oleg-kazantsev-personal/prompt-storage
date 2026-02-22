using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Infrastructure.Persistence.Configurations;

public sealed class PerformanceConfiguration : IEntityTypeConfiguration<Performance>    
{
    public void Configure(EntityTypeBuilder<Performance> builder)
    {
        builder.ToTable("Performance");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Title)
               .IsRequired()
               .HasMaxLength(120);

        builder.Property(p => p.Description)
               .HasMaxLength(1000);

        builder.HasOne(p => p.Show)
               .WithMany(s => s.Performances)
               .HasForeignKey(p => p.ShowId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(p => p.Title);
        builder.HasIndex(p => p.CreatedAtUtc);
    }
}  