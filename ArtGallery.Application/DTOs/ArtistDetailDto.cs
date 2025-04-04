namespace ArtGallery.Application.DTOs;

public class ArtistDetailDto : ArtistDto
{
    public BiographyDto Biography { get; set; }
    public ICollection<ArtistImageDto> Images { get; set; } = new List<ArtistImageDto>();
    public ICollection<PaintingListDto> Paintings { get; set; } = new List<PaintingListDto>();
}