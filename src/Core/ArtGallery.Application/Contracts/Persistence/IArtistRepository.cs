using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Contracts.Persistence;

public interface IArtistRepository : IGenericRepository<Artist>
{
    Task<Artist> GetArtistWithPaintingsAsync(Guid artistId);
    Task<IReadOnlyList<string>> GetAllNationalitiesAsync();
}
