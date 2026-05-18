using ArtGallery.Domain.Entities;

namespace ArtGallery.Application.Contracts.Persistence;

public interface ITagRepository : IGenericRepository<Tag>
{
    Task<Tag?> GetTagByNameAsync(string name);
    Task<IReadOnlyList<Tag>> GetAllTagsAsync();
}
