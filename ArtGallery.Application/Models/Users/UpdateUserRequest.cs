namespace ArtGallery.Application.Models.Users;


public class UpdateUserRequest : UpdateProfileRequest
{
    public string Email { get; set; }
    public string UserName { get; set; }
}