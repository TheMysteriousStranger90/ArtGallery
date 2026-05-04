using Microsoft.AspNetCore.RateLimiting;

namespace ArtGallery.WebAPI.Extensions;

public static class RateLimitingExtensions
{
    public static void ConfigureRateLimiting(this WebApplicationBuilder builder)
    {
        builder.Services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            
            options.AddFixedWindowLimiter("registration", opt =>
            {
                opt.Window = TimeSpan.FromMinutes(1);
                opt.PermitLimit = 3;
                opt.QueueLimit = 0;
            });
            
            options.AddFixedWindowLimiter("authentication", opt =>
            {
                opt.Window = TimeSpan.FromMinutes(1);
                opt.PermitLimit = 5;
                opt.QueueLimit = 0;
            });
        });
    }
}