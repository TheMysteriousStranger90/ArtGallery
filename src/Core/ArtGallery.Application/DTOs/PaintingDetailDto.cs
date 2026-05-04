namespace ArtGallery.Application.DTOs;

public class PaintingDetailDto : PaintingDto
{
    public ICollection<PaintingImageDto> Images { get; set; } = new List<PaintingImageDto>();
    public ICollection<PaintingTagDto> Tags { get; set; } = new List<PaintingTagDto>();
    public ICollection<ExhibitionBriefDto> Exhibitions { get; set; } = new List<ExhibitionBriefDto>();
}