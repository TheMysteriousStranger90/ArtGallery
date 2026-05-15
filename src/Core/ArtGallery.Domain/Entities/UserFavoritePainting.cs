using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class UserFavoritePainting : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public Guid PaintingId { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
    public virtual Painting Painting { get; set; } = null!;
}
