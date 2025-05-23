using ArtGallery.WebAPI.Errors;
using Serilog;

namespace ArtGallery.WebAPI.Extensions;

public static class ErrorAlertExtensions
{
    public static IServiceCollection ConfigureErrorAlerts(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IErrorNotifier>(sp => 
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            
            return new ErrorNotifier(configuration, Log.Logger);
        });
        
        return builder.Services;
    }
}