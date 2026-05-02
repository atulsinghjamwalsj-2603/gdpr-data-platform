using System.Net;
using System.Text.Json;
using FluentValidation;
using Gdpr.Application.DTOs;

namespace Gdpr.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
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
            _logger.LogError(ex, "Unhandled exception occurred");

            await HandleException(context, ex);
        }
    }

    private static Task HandleException(HttpContext context, Exception ex)
{
    HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
    string message = "Something went wrong";

    switch (ex)
    {
        case ValidationException validationException:
            statusCode = HttpStatusCode.BadRequest;
            message = string.Join(", ", validationException.Errors.Select(e => e.ErrorMessage));
            break;

        case ArgumentException argumentException:
            statusCode = HttpStatusCode.BadRequest;
            message = argumentException.Message;
            break;
    }

    context.Response.ContentType = "application/json";
    context.Response.StatusCode = (int)statusCode;

    var response = ApiResponse<string>.Failure(message);

    var json = JsonSerializer.Serialize(response);

    return context.Response.WriteAsync(json);
}
}