using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PromptStorageApi.Infrastructure.Persistence;

namespace PromptStorageApi.Infrastructure;

public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostEnvironment env)
    {
        var connectionString = configuration.GetConnectionString("PromptStorageDb")
                 ?? throw new InvalidOperationException("Missing connection string: PromptStorageDb");

        services.AddDbContext<PromptStorageDbContext>(options =>
        {
            options.UseSqlServer(connectionString, sql =>
            {
                sql.EnableRetryOnFailure();
                sql.CommandTimeout(30);
            });

            options.EnableDetailedErrors();
            options.EnableSensitiveDataLogging(env.IsDevelopment());
        });

        return services;
    }
}