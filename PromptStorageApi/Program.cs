using Microsoft.AspNetCore.Mvc;
using PromptStorageApi.Application;
using PromptStorageApi.Infrastructure;
using PromptStorageApi.Infrastructure.Exceptions;

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

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();

app.Run();
