namespace ArtGallery.Application.DTOs;

public class PaintingListDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public int CreationYear { get; set; }
    public string ImageUrl { get; set; }
}