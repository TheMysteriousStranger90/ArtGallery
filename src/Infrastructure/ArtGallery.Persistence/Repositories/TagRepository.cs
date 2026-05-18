using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Entities;
using ArtGallery.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Repositories;

public class TagRepository : GenericRepository<Tag>, ITagRepository
{
    public TagRepository(ArtGalleryDbContext context) : base(context)
    {
    }

    public async Task<Tag?> GetTagByNameAsync(string name)
    {
        return await _context.Set<Tag>()
            .FirstOrDefaultAsync(t => t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<IReadOnlyList<Tag>> GetAllTagsAsync()
    {
        return await _context.Set<Tag>()
            .OrderBy(t => t.Name)
            .ToListAsync();
    }
}
