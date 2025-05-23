using ArtGallery.Application.Exceptions;
using ArtGallery.WebAPI.Errors;

namespace ArtGallery.WebAPI.Middleware;

public class GlobalExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    public GlobalExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionHandlingMiddleware> logger,
        IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (CustomException ex)
        {
            _logger.LogError(ex, "Custom Exception: {Message}", ex.Message);
            
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)ex.StatusCode;

            var errorResponse = new ErrorResponse
            {
                Errors = ex.ErrorMessages?.Count > 0 
                    ? ex.ErrorMessages 
                    : new List<string> { ex.Message }
            };

            await response.WriteAsJsonAsync(errorResponse);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred");
        
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = StatusCodes.Status500InternalServerError;

            var errorResponse = _env.IsDevelopment() 
                ? new ErrorResponse
                {
                    Errors = new List<string> { ex.Message },
                    StackTrace = ex.StackTrace
                }
                : new ErrorResponse
                {
                    Errors = new List<string> { "An unexpected error occurred" }
                };

            await response.WriteAsJsonAsync(errorResponse);
        }
    }
}