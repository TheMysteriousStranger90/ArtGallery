using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Contracts.Persistence;

public interface IArtistRepository : IGenericRepository<Artist>
{
    Task<IReadOnlyList<Artist>> GetArtistsByNationalityAsync(string nationality);
    Task<Artist> GetArtistWithPaintingsAsync(Guid artistId);
    Task<IReadOnlyList<string>> GetAllNationalitiesAsync();
}