namespace ArtGallery.Application.DTOs;

public class ArtistBriefDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Nationality { get; set; }
}