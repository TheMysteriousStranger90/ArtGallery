namespace ArtGallery.Application.DTOs;

public class ExhibitionPaintingDto
{
    public Guid PaintingId { get; set; }
    public string Title { get; set; }
    public string ArtistName { get; set; }
    public int CreationYear { get; set; }
    public string ImageUrl { get; set; }
}