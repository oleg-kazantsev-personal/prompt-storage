using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromptStorageApi.Application;
using PromptStorageApi.Infrastructure;
using PromptStorageApi.Infrastructure.Exceptions;
using PromptStorageApi.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// App layers
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration, builder.Environment);

// Optional: common API behavior tweaks (handy for validation)
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // If you want to keep the default automatic 400 responses, leave this as-is.
    // options.SuppressModelStateInvalidFilter = false;
});

// Configure Kestrel.
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5064);

    options.ListenAnyIP(7244, listenOptions =>
    {
        listenOptions.UseHttps("mini256.local+3.p12", "changeit");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else 
{
    app.UseHsts();
}

// Apply any pending EF Core migrations at startup. In production, you might want to handle this differently (e.g. manual migrations or a separate migration tool).
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;
    var logger = service.GetRequiredService<ILogger<Program>>();

try
    {
        logger.LogInformation("Applying database migrations...");

        var db = service.GetRequiredService<PromptStorageDbContext>();
        await db.Database.MigrateAsync();

        logger.LogInformation("Database migrations applied successfully.");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "An error occurred while applying database migrations.");
        throw;
    }
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
