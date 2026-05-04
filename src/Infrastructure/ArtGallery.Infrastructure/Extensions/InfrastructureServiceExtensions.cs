using ArtGallery.Application.Contracts.Infrastructure;
using ArtGallery.Application.Helpers;
using ArtGallery.Infrastructure.Image;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtGallery.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
        
        services.AddScoped<IImageService, ImageService>();
        
        return services;
    }
}