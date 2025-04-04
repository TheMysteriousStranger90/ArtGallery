using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class PaintingImage : BaseEntity
{
    public string PictureUrl { get; set; }
    public bool IsMain { get; set; }
    public string PublicId { get; set; }
    
    public Guid PaintingId { get; set; }
    public virtual Painting Painting { get; set; }
}