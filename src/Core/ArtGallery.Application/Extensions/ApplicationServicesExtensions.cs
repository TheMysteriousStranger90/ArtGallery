using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Cache;
using ArtGallery.Application.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtGallery.Application.Extensions;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services,
        IConfiguration config)
    {

        services.AddAutoMapper(cfg => cfg.AddProfile<ArtistMappingProfile>());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

        services.AddSingleton<ICacheKeyService, CacheKeyService>();

        return services;
    }
}
