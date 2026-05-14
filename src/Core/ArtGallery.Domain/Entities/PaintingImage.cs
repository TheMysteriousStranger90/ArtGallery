using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class PaintingImage : BaseEntity
{
    public string PictureUrl { get; set; } = string.Empty;
    public bool IsMain { get; set; }
    public string PublicId { get; set; } = string.Empty;

    public Guid PaintingId { get; set; }
    public virtual Painting Painting { get; set; } = null!;
}
