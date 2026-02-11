using System.Net;
using System.Text.Json;

namespace HelloMotors.Middlewares;

public class GlobalExceptionMiddleware //Request → Middleware → Controller → Service → Banco
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next) //chama o próximo passo da pipeline, no nosso caso, o controller
    {
        _next = next; 
    }

    public async Task InvokeAsync(HttpContext context)  //método obrigatório do middleware
    {
        try
        {
            await _next(context);   //se não conseguir avançar (exception) trata o erro
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
        context.Response.ContentType = "application/json"; //define que a resposta será um JSON
        context.Response.StatusCode = (int)statusCode; //define o código HTTP da resposta

        var response = new  //cria o objeto que será transformado em JSON
        {
            status = context.Response.StatusCode,
            error = message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response)); //serve pra retornar o erro formatado
    }
}
