using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class PaintingTag : BaseEntity
{
    public Guid PaintingId { get; set; }
    public Guid TagId { get; set; }

    public virtual Painting Painting { get; set; } = null!;
    public virtual Tag Tag { get; set; } = null!;
}
