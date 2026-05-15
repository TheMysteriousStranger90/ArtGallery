using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class UserFavoriteArtist : BaseEntity
{
    public string UserId { get; set; } = string.Empty;
    public Guid ArtistId { get; set; }

    public virtual ApplicationUser User { get; set; } = null!;
    public virtual Artist Artist { get; set; } = null!;
}
