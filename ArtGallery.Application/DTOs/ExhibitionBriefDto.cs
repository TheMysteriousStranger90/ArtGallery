namespace ArtGallery.Application.DTOs;

public class ExhibitionBriefDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string MuseumName { get; set; }
}