using System.Net;
using System.Text.Json;
using FluentValidation;

namespace Nexora.API.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        Exception exception)
    {
        context.Response.ContentType = "application/json";

        HttpStatusCode statusCode;
        object response;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;

                response = new
                {
                    success = false,
                    message = "Validation failed.",
                    errors = validationException.Errors
                        .Select(e => e.ErrorMessage)
                        .ToList()
                };
                break;

            case InvalidOperationException:
                statusCode = HttpStatusCode.Conflict;

                response = new
                {
                    success = false,
                    message = exception.Message
                };
                break;

            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized;

                response = new
                {
                    success = false,
                    message = exception.Message
                };
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;

                response = new
                {
                    success = false,
                    message = "An unexpected error occurred."
                };
                break;
        }

        context.Response.StatusCode = (int)statusCode;

        var json = JsonSerializer.Serialize(response);

        await context.Response.WriteAsync(json);
    }
}