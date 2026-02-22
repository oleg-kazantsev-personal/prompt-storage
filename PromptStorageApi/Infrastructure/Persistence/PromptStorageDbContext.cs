using Microsoft.EntityFrameworkCore;
using PromptStorageApi.Domain.Entities;
using PromptStorageApi.Domain.Common;
using System.Linq.Expressions;

namespace PromptStorageApi.Infrastructure.Persistence;

public sealed class PromptStorageDbContext : DbContext
{
    public DbSet<AIGenerator> AIGenerators => Set<AIGenerator>();
    public DbSet<Performance> Performances => Set<Performance>();
    public DbSet<Prompt> Prompts => Set<Prompt>();
    public DbSet<Scene> Scenes => Set<Scene>();
    public DbSet<Show> Shows => Set<Show>();

    public PromptStorageDbContext(DbContextOptions<PromptStorageDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasDefaultSchema("dbo");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PromptStorageDbContext).Assembly);

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(AuditableEntity).IsAssignableFrom(entityType.ClrType))
            {
                modelBuilder.Entity(entityType.ClrType)
                    .HasQueryFilter(
                        GenerateIsDeletedRestriction(entityType.ClrType));
            }
        }
    }

    public static LambdaExpression GenerateIsDeletedRestriction(Type type)
    {
        var param = Expression.Parameter(type, "e");
        var prop = Expression.Property(param, nameof(AuditableEntity.IsDeleted));
        var condition = Expression.Equal(prop, Expression.Constant(false));

        return Expression.Lambda(condition, param);
    }

    public override int SaveChanges()
    {
        ApplyAuditInfo();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyAuditInfo();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void ApplyAuditInfo()    
    {
        var entries = ChangeTracker.Entries<AuditableEntity>();
        var utcNow = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAtUtc = utcNow;
                entry.Entity.UpdatedAtUtc = utcNow;

                entry.Entity.CreatedBy = "TODO: current user";
                entry.Entity.UpdatedBy = "TODO: current user";
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAtUtc = utcNow;
                entry.Entity.UpdatedBy = "TODO: Get current user";

                // Prevent accidental updates of Created fields
                entry.Property(x => x.CreatedAtUtc).IsModified = false;
                entry.Property(x => x.CreatedBy).IsModified = false;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.State = EntityState.Modified;
                entry.Entity.IsDeleted = true;
                entry.Entity.DeletedAtUtc = utcNow;
            }
        }
    }
}