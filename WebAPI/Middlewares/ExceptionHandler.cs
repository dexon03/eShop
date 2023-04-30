using System.Net;
using System.Text.Json;
using Domain.Exceptions;
using FluentValidation;

namespace WebAPI.Middlewares;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;

    public ExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContent content)
    {
        
    }
    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = HttpStatusCode.InternalServerError;
        var result = string.Empty;
        switch (exception)
        {
            case ValidationException validationException:
                code = HttpStatusCode.BadRequest;
                result = JsonSerializer.Serialize(validationException);
                break;
            case NotFoundException notFoundException:
                code = HttpStatusCode.NotFound;
                break;
            case BadRequestException invalidUserRegistrationException:
                code = HttpStatusCode.UnprocessableEntity;
                break;
            case ArgumentException argumentException:
                code = HttpStatusCode.BadRequest;
                break;
            case IOException ioException:
                code = HttpStatusCode.BadRequest;
                break;
            case KeyNotFoundException keyNotFoundException:
                code = HttpStatusCode.NotFound;
                break;
            case InvalidOperationException invalidOperationException:
                code = HttpStatusCode.BadRequest;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        if (result == string.Empty)
        {
            result = JsonSerializer.Serialize(new {error = exception.Message});
        }

        return context.Response.WriteAsync(result);
    }
}