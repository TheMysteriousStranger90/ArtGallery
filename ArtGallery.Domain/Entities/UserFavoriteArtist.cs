using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class UserFavoriteArtist : BaseEntity
{
    public string UserId { get; set; }
    public Guid ArtistId { get; set; }

    public virtual ApplicationUser User { get; set; } 
    public virtual Artist Artist { get; set; }
}