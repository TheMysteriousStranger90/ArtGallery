namespace ArtGallery.WebAPI.Extensions;

public static class CorsExtensions
{
    public static void ConfigureCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            
            // You can add more policies here for different scenarios
            // For example:
            /*
            options.AddPolicy("Production", builder => builder
                .WithOrigins("https://example.com")
                .AllowAnyMethod()
                .AllowAnyHeader());
            */
        });
    }
}