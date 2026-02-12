using System.Net;
using System.Text.Json;

namespace HelloMotors.Middlewares;

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
        catch (ArgumentException ex)
        {
            await HandleExceptionAsync(context, ex.Message, HttpStatusCode.BadRequest);
        }
        catch (KeyNotFoundException ex)
        {
            await HandleExceptionAsync(context, ex.Message, HttpStatusCode.NotFound);
        }
        catch (Exception)
        {
            await HandleExceptionAsync(context, "Erro interno no servidor", HttpStatusCode.InternalServerError);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, string message, HttpStatusCode statusCode)
    {
        context.Response.ContentType = "application/json"; 
        context.Response.StatusCode = (int)statusCode; 

        var response = new  
        {
            status = context.Response.StatusCode,
            error = message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response)); 
    }
}
