using Microsoft.AspNetCore.Identity;

namespace ArtGallery.Domain.Entities;

public class AppUserRole : IdentityUserRole<string>
{
    public ApplicationUser User { get; set; }
    public AppRole Role { get; set; }
}