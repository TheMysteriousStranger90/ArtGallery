using ArtGallery.WebAPI.Middleware;

namespace ArtGallery.WebAPI.Extensions;

public static class RequestLoggingMiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>();
    }
}