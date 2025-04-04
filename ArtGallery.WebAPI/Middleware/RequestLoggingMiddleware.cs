namespace ArtGallery.WebAPI.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var start = DateTime.UtcNow;

        context.Request.EnableBuffering();

        try
        {
            await _next(context);
        }
        finally
        {
            var elapsed = DateTime.UtcNow - start;

            _logger.LogInformation(
                "Request {Method} {Path} => {StatusCode} (Took: {ElapsedMs}ms)",
                context.Request?.Method,
                context.Request?.Path.Value,
                context.Response?.StatusCode,
                elapsed.TotalMilliseconds);
        }
    }
}