using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class ArtistImage : BaseEntity
{
    public string PictureUrl { get; set; }
    public bool IsMain { get; set; }
    public string PublicId { get; set; }
    
    public Guid ArtistId { get; set; }
    public virtual Artist Artist { get; set; }
}