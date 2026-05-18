using ArtGallery.Domain.Common;
using ArtGallery.Domain.Entities.Enums;

namespace ArtGallery.Domain.Entities;

public class Painting : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int CreationYear { get; set; }
    public string Medium { get; set; } = string.Empty;
    public string Dimensions { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public PaintType PaintType { get; set; }

    public Guid ArtistId { get; set; }
    public Guid? GenreId { get; set; }
    public Guid? MuseumId { get; set; }

    public virtual Artist Artist { get; set; } = null!;
    public virtual Genre Genre { get; set; } = null!;
    public virtual Museum Museum { get; set; } = null!;
    public virtual ICollection<PaintingExhibition> Exhibitions { get; set; } = new List<PaintingExhibition>();

    public virtual ICollection<UserFavoritePainting> UserFavoritePaintings { get; set; } =
        new List<UserFavoritePainting>();

    public virtual ICollection<PaintingTag> Tags { get; set; } = new List<PaintingTag>();
    public virtual ICollection<PaintingImage> PaintingImages { get; set; } = new List<PaintingImage>();
}
