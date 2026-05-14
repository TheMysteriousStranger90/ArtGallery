using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Artist : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string Nationality { get; set; } = string.Empty;

    public virtual Biography Biography { get; set; } = null!;

    public virtual ICollection<ArtistImage> ArtistImage { get; set; } = new List<ArtistImage>();
    public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
    public virtual ICollection<UserFavoriteArtist> UserFavoriteArtists { get; set; } = new List<UserFavoriteArtist>();
}
