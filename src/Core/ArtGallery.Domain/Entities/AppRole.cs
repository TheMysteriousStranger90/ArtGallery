using Microsoft.AspNetCore.Identity;

namespace ArtGallery.Domain.Entities;

public class AppRole : IdentityRole
{
    public ICollection<AppUserRole> UserRoles { get; set; }
}