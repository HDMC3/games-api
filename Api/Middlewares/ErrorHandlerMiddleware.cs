using System.Net;
using System.Text.Json;
using Aplication.Exceptions;

namespace Api.Middlewares;

public class ErrorHandlerMiddleware {
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task Invoke(HttpContext context) {
        try
        {
            await _next(context);
        }
        catch (System.Exception error)
        {
            context.Response.ContentType = "application/json";
            Console.WriteLine(error);
            switch(error) {
                case QueryException e:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var result = JsonSerializer.Serialize(new {message = error.Message});
            await context.Response.WriteAsync(result);
        }
    }
}