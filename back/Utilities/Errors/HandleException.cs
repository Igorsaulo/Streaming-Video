using System.Net;
using System.Text.Json;

// Middleware personalizado para lidar com exceções
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    // Método para invocar o middleware
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Tente continuar a execução da solicitação
            await _next(context);
        }
        catch (Exception ex)
        {
            // Em caso de exceção, registre o erro no log
            _logger.LogError($"Algo deu errado: {ex}");
            // Chame o método para lidar com a exceção
            await HandleExceptionAsync(context, ex);
        }
    }

    // Método para lidar com exceções e retornar uma resposta JSON
    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        // Retorne detalhes de erro como uma resposta JSON
        return context.Response.WriteAsync(
            new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString()
        );
    }
}

// Classe para representar detalhes de erro
public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set; }

    // Sobrescreva o método ToString para serializar os detalhes de erro em JSON
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}
