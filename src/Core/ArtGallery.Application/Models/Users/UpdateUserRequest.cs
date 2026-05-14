namespace ArtGallery.Application.Models.Users;


public class UpdateUserRequest : UpdateProfileRequest
{
    public new string? FirstName { get; set; }
    public new string? LastName { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
}
