using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Contracts.Persistence;

public interface IExhibitionRepository : IGenericRepository<Exhibition>
{
    Task<IReadOnlyList<Exhibition>> GetCurrentExhibitionsAsync();
    Task<IReadOnlyList<Exhibition>> GetUpcomingExhibitionsAsync();
    Task<IReadOnlyList<Exhibition>> GetPastExhibitionsAsync();
    Task<Exhibition> GetExhibitionWithPaintingsAsync(Guid exhibitionId);
}