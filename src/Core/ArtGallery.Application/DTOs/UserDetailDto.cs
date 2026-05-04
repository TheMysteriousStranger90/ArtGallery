namespace ArtGallery.Application.DTOs;

public class UserDetailDto : UserProfileDto
{
    public bool EmailConfirmed { get; set; }
    
    public ICollection<PaintingBriefDto> FavoritePaintings { get; set; } = new List<PaintingBriefDto>();
    public ICollection<ArtistBriefDto> FavoriteArtists { get; set; } = new List<ArtistBriefDto>();
}
