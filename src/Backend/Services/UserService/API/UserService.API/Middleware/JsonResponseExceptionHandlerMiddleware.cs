using System.Net;
using System.Text.Json;
using FluentValidation;
using UserService.Application.Common.Constants;
using UserService.Application.ViewModels;
using UserService.Domain.Exceptions;

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
        IEnumerable<ErrorViewModel> errors;

        switch (exception)
        {
            case AggregateErrorException manyErrorsException:
                code = HttpStatusCode.BadRequest;
                errors = manyErrorsException.Errors;
                break;
            case NotFoundException notFoundException:
                code = HttpStatusCode.NotFound;
                errors = new List<ErrorViewModel> { new(ErrorConstants.EmptyPropertyName, notFoundException.Message) };
                break;
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                errors = validationException.Errors.Select(error =>
                    new ErrorViewModel(error.PropertyName, error.ErrorMessage));
                break;
            default:
                errors = new List<ErrorViewModel> { new(ErrorConstants.EmptyPropertyName, exception.Message) };
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;

        var result = JsonSerializer.Serialize(new { code, errors },
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
        return context.Response.WriteAsync(result);
    }
}