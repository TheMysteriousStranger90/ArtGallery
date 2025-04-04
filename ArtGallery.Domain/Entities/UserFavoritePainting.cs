using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class UserFavoritePainting : BaseEntity
{
    public string UserId { get; set; }
    public Guid PaintingId { get; set; }

    public virtual ApplicationUser User { get; set; }
    public virtual Painting Painting { get; set; }
}