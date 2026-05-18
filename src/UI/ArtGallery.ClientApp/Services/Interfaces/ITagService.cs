using ArtGallery.ClientApp.Constants;

namespace ArtGallery.ClientApp.Services.Interfaces;

public interface ITagService
{
    Task<ICollection<TagDto>> GetTagsAsync(string apiVersion = Const.DefaultApiVersion);
    Task<TagDto?> GetTagByIdAsync(Guid id, string apiVersion = Const.DefaultApiVersion);
    Task<TagDto?> CreateTagAsync(string name, string apiVersion = Const.DefaultApiVersion);
    Task<TagDto?> UpdateTagAsync(Guid id, string name, string apiVersion = Const.DefaultApiVersion);
    Task<bool> DeleteTagAsync(Guid id, string apiVersion = Const.DefaultApiVersion);
}