using System.Net;
using System.Text.Json;

namespace OnDijon;
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception caught");

            var statusCode = HttpStatusCode.InternalServerError;
            var message = _env.IsDevelopment() ? ex.Message : "Une erreur inattendue s'est produite";

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var result = JsonSerializer.Serialize(new { message = message });
            await context.Response.WriteAsync(result);
        }
    }
}




