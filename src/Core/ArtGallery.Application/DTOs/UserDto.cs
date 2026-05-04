namespace ArtGallery.Application.DTOs;

public class UserDto
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}".Trim();
    public DateTime Created { get; set; }
    public DateTime? LastActive { get; set; }
    public IList<string> Roles { get; set; } = new List<string>();

    public int FavoritePaintingsCount { get; set; }
    public int FavoriteArtistsCount { get; set; }
}