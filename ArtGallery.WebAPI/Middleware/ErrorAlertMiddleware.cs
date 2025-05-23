using ArtGallery.WebAPI.Errors;

namespace ArtGallery.WebAPI.Middleware;

public class ErrorAlertMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IErrorNotifier _errorNotifier;
    private readonly ILogger<ErrorAlertMiddleware> _logger;

    public ErrorAlertMiddleware(
        RequestDelegate next,
        IErrorNotifier errorNotifier,
        ILogger<ErrorAlertMiddleware> logger)
    {
        _next = next;
        _errorNotifier = errorNotifier;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unhandled exception occurred");

            await _errorNotifier.NotifyErrorAsync(ex,
                $"Unhandled exception in request {context.Request.Method} {context.Request.Path}",
                new
                {
                    RequestPath = context.Request.Path,
                    RequestMethod = context.Request.Method,
                    UserAgent = context.Request.Headers["User-Agent"].ToString()
                });

            throw;
        }
    }
}