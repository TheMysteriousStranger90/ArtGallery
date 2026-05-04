using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Contracts.Persistence;

public interface IPaintingRepository : IGenericRepository<Painting>
{
    Task<Painting> GetPaintingWithDetailsAsync(Guid id);
}