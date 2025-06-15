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
                        "http://localhost:5181",
                        "https://localhost:8083"
                    )
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            }
            else
            {
                options.AddPolicy("Open", policy => policy
                    .WithOrigins(
                        // "https://yourdomain.com", // Add your actual production domain here
                        // "https://www.yourdomain.com", // Add your actual production domain here
                        "https://localhost:8083"
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