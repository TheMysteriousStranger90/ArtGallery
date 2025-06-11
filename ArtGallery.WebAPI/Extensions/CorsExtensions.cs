namespace ArtGallery.WebAPI.Extensions;

public static class CorsExtensions
{
    public static void ConfigureCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            if (builder.Environment.IsDevelopment())
            {
                options.AddPolicy("Open", policy => policy
                    .WithOrigins(
                        "https://localhost:7179", 
                        "http://localhost:5181"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            }
            else
            {
                // In production, restrict CORS to specific domains
                options.AddPolicy("Open", policy => policy
                    .WithOrigins(
                        "https://yourdomain.com",
                        "https://www.yourdomain.com"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            }

            options.AddPolicy("Public", policy => policy
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });
    }
}