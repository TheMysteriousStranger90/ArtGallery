namespace ArtGallery.Application.DTOs;

public class MuseumDetailDto : MuseumBriefDto
{
    public string Description { get; set; }
    public string Address { get; set; }
    public string WebsiteUrl { get; set; }
    public ICollection<PaintingBriefDto> Paintings { get; set; } = new List<PaintingBriefDto>();
}
