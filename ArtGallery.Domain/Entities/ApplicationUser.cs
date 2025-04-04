using Microsoft.AspNetCore.Identity;

namespace ArtGallery.Domain.Entities;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime? LastActive { get; set; }
    
    public ICollection<AppUserRole> UserRoles { get; set; }
    
    public virtual ICollection<UserFavoritePainting> FavoritePaintings { get; set; } = new List<UserFavoritePainting>();
    public virtual ICollection<UserFavoriteArtist> FavoriteArtists { get; set; } = new List<UserFavoriteArtist>();
}
