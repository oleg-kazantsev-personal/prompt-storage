using System.Net;
using System.Text.Json;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Runtime.ExceptionServices;

namespace PromptStorageApi.Infrastructure.Exceptions;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHostEnvironment _env;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        IHostEnvironment env,
        ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _env = env;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        if (context.Response.HasStarted)
            ExceptionDispatchInfo.Capture(exception).Throw();

        context.Response.ContentType = "application/json";

        var response = exception switch
        {
            ValidationException validationException
                => BuildValidationResponse(validationException),

            KeyNotFoundException notFoundException
                => BuildResponse(HttpStatusCode.NotFound, notFoundException.Message),

            _ => BuildResponse(HttpStatusCode.InternalServerError,
                               _env.IsDevelopment()
                                   ? exception.ToString()
                                   : "An unexpected error occurred.")
        };

        context.Response.StatusCode = (int)response.StatusCode;

        var json = JsonSerializer.Serialize(response.Body);
        await context.Response.WriteAsync(json);
    }

    private (HttpStatusCode StatusCode, object Body)
        BuildValidationResponse(ValidationException ex)
    {
        var errors = ex.Errors
            .GroupBy(e => e.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(e => e.ErrorMessage).ToArray());

        _logger.LogWarning("Validation failed: {@Errors}", errors);

        return (
            HttpStatusCode.BadRequest,
            new
            {
                title = "Validation failed",
                status = 400,
                errors
            });
    }

    private (HttpStatusCode StatusCode, object Body)
        BuildResponse(HttpStatusCode statusCode, string message)
    {

        switch (statusCode)
        {
            case HttpStatusCode.NotFound:
                _logger.LogInformation("Resource not found: {Message}", message);
                break;

            case HttpStatusCode.InternalServerError:
                _logger.LogError("Internal server error: {Message}", message);
                break;

            default:
                _logger.LogInformation("An error occurred: {Message}", message);
                break;
        }

        return (
            statusCode,
            new
            {
                title = message,
                status = (int)statusCode
            });
    }
}
