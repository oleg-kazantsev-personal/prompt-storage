using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PromptStorageApi.Domain.Entities;

namespace PromptStorageApi.Infrastructure.Persistence.Configurations;

public sealed class ShowConfiguration : IEntityTypeConfiguration<Show>  
{
    public void Configure(EntityTypeBuilder<Show> builder)
    {
        builder.ToTable("Show");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(120);

        builder.Property(s => s.Description)
               .HasMaxLength(1000);

        builder.HasIndex(s => s.Name);
        builder.HasIndex(s => s.CreatedAtUtc);
    }
}