using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Contracts.Persistence;

public interface IMuseumRepository : IGenericRepository<Museum>
{
    Task<Museum> GetMuseumWithPaintingsAsync(Guid museumId);
    Task<IReadOnlyList<Museum>> GetMuseumsByCountryAsync(Guid countryId);
    Task<IReadOnlyList<Museum>> GetMuseumsByCityAsync(Guid cityId);
}