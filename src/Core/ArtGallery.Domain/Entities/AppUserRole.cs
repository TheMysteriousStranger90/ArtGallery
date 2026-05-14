using Microsoft.AspNetCore.Identity;

namespace ArtGallery.Domain.Entities;

public class AppUserRole : IdentityUserRole<string>
{
    public ApplicationUser User { get; set; } = null!;
    public AppRole Role { get; set; } = null!;
}
