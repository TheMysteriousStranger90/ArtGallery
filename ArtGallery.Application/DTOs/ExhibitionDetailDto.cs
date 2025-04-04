namespace ArtGallery.Application.DTOs;

public class ExhibitionDetailDto : ExhibitionDto
{
    public ICollection<ExhibitionPaintingDto> Paintings { get; set; } = new List<ExhibitionPaintingDto>();
}