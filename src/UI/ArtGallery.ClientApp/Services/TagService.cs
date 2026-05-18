using ArtGallery.ClientApp.Constants;
using ArtGallery.ClientApp.Services.Interfaces;

namespace ArtGallery.ClientApp.Services;

public class TagService : ITagService
{
    private readonly IClient _client;
    private readonly ILogger<TagService> _logger;

    public TagService(IClient client, ILogger<TagService> logger)
    {
        _client = client;
        _logger = logger;
    }

    public async Task<ICollection<TagDto>> GetTagsAsync(string apiVersion = Const.DefaultApiVersion)
    {
        try
        {
            return await _client.TagsGETAllAsync(apiVersion);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get tags");
            return Array.Empty<TagDto>();
        }
    }

    public async Task<TagDto?> GetTagByIdAsync(Guid id, string apiVersion = Const.DefaultApiVersion)
    {
        try
        {
            return await _client.TagsGETByIdAsync(id, apiVersion);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get tag {Id}", id);
            return null;
        }
    }

    public async Task<TagDto?> CreateTagAsync(string name, string apiVersion = Const.DefaultApiVersion)
    {
        try
        {
            return await _client.TagsPOSTAsync(apiVersion, name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create tag {Name}", name);
            return null;
        }
    }

    public async Task<TagDto?> UpdateTagAsync(Guid id, string name, string apiVersion = Const.DefaultApiVersion)
    {
        try
        {
            return await _client.TagsPUTAsync(id, apiVersion, name);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to update tag {Id}", id);
            return null;
        }
    }

    public async Task<bool> DeleteTagAsync(Guid id, string apiVersion = Const.DefaultApiVersion)
    {
        try
        {
            await _client.TagsDELETEByIdAsync(id, apiVersion);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to delete tag {Id}", id);
            return false;
        }
    }
}