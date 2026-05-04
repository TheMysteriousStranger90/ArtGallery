using ArtGallery.Domain.Entities.Enums;

namespace ArtGallery.Application.DTOs;

public class PaintingBriefDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CreationYear { get; set; }
    public string Medium { get; set; }
    public string Dimensions { get; set; }
    public string ImageUrl { get; set; }
    public PaintType PaintType { get; set; }
    public string PaintTypeName => PaintType.ToString();
    
    public ArtistBriefDto Artist { get; set; }
    public GenreDto Genre { get; set; }
    public MuseumBriefDto Museum { get; set; }
}