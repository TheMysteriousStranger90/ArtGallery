namespace ArtGallery.Application.DTOs;

public class UserDetailDto : UserProfileDto
{
    public bool EmailConfirmed { get; set; }
    // Add additional admin-visible properties
}
