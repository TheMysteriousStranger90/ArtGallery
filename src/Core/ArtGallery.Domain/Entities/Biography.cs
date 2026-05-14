using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Biography : BaseEntity
{
    public string Content { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string References { get; set; } = string.Empty;

    public Guid ArtistId { get; set; }
    public virtual Artist Artist { get; set; } = null!;
}
