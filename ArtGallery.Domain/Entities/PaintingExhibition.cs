using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class PaintingExhibition : BaseEntity
{
    public Guid PaintingId { get; set; }
    public Guid ExhibitionId { get; set; }

    public virtual Painting Painting { get; set; }
    public virtual Exhibition Exhibition { get; set; }
}