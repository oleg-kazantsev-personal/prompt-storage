using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PromptStorageApi.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database context configuration.

builder.Services.AddDbContext<PromptStorageDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PromptStorageDb")
         ?? throw new InvalidOperationException("Missing connection string: PromptStorageDb");
         
    options.UseSqlServer(
        connectionString,
        sql =>
        {
            // Good defaults for SQL Server
            sql.EnableRetryOnFailure();
            sql.CommandTimeout(30);
        });

    // Helpful while developing (turn off in prod)
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging(builder.Environment.IsDevelopment());
});

// Optional: common API behavior tweaks (handy for validation)
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    // If you want to keep the default automatic 400 responses, leave this as-is.
    // options.SuppressModelStateInvalidFilter = false;
});


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}
else 
{
    app.UseExceptionHandler();
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

// Health check endpoint 
app.MapGet("/health", () => Results.Ok(new { status = "ok" }))
   .WithName("Health");

app.Run();
