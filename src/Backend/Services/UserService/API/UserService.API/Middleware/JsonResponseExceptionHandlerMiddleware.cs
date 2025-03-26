using System.Net;
using System.Text.Json;
using FluentValidation;
using UserService.Application.Exceptions;

namespace UserService.API.Middleware;

public class JsonResponseExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public JsonResponseExceptionHandlerMiddleware(RequestDelegate next)
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

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        Dictionary<string, string> errors;

        switch (exception)
        {
            case ManyErrorsException manyErrorsException:
                code = HttpStatusCode.BadRequest;
                errors = manyErrorsException.Errors.ToDictionary();
                break;
            case NotFoundException notFoundException:
                code = HttpStatusCode.NotFound;
                errors = new Dictionary<string, string> { { "System", notFoundException.Message } };
                break;
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                errors = new Dictionary<string, string>(
                    validationException.Errors
                        .ToDictionary(error => error.PropertyName,
                            error => error.ErrorMessage));
                break;
            default:
                errors = new Dictionary<string, string> { { "System", exception.Message } };
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        var result = JsonSerializer.Serialize(new { code, errors });
        return context.Response.WriteAsync(result);
    }
}