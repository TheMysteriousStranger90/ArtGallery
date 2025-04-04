using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Persistence.Context;
using ArtGallery.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtGallery.Persistence.Extensions;

public static class PersistenceServiceExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ArtGalleryDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ArtGalleryDbConnection"),
                b => b.MigrationsAssembly(typeof(ArtGalleryDbContext).Assembly.FullName));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IArtistRepository, ArtistRepository>();
        services.AddScoped<IPaintingRepository, PaintingRepository>();
        services.AddScoped<IExhibitionRepository, ExhibitionRepository>();
        services.AddScoped<IMuseumRepository, MuseumRepository>();
        services.AddScoped<IUserFavoritesRepository, UserFavoritesRepository>();
        services.AddScoped<IImageRepository, ImageRepository>();
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}