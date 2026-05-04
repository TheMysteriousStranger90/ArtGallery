using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Biography : BaseEntity
{
    public string Content { get; set; }
    public string ShortDescription { get; set; }
    public string References { get; set; }
    
    public Guid ArtistId { get; set; }
    public virtual Artist Artist { get; set; }
}