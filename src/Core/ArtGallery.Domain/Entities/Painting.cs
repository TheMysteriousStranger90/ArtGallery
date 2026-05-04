using ArtGallery.Domain.Common;
using ArtGallery.Domain.Entities.Enums;

namespace ArtGallery.Domain.Entities;

public class Painting : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int CreationYear { get; set; }
    public string Medium { get; set; }
    public string Dimensions { get; set; }
    public string ImageUrl { get; set; }
    public PaintType PaintType { get; set; }

    public Guid ArtistId { get; set; }
    public Guid? GenreId { get; set; }
    public Guid? MuseumId { get; set; }
    
    public virtual Artist Artist { get; set; }
    public virtual Genre Genre { get; set; }
    public virtual Museum Museum { get; set; }
    public virtual ICollection<PaintingExhibition> Exhibitions { get; set; } = new List<PaintingExhibition>();
    public virtual ICollection<UserFavoritePainting> UserFavoritePaintings { get; set; } = new List<UserFavoritePainting>();
    public virtual ICollection<PaintingTag> Tags { get; set; } = new List<PaintingTag>();
    public virtual ICollection<PaintingImage> PaintingImages { get; set; } = new List<PaintingImage>();
}