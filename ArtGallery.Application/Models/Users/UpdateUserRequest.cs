namespace ArtGallery.Application.Models.Users;


public class UpdateUserRequest : UpdateProfileRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
}