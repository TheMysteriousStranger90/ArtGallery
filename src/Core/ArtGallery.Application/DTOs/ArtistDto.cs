namespace ArtGallery.Application.DTOs;

public class ArtistDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string Nationality { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string PictureUrl { get; set; }
}