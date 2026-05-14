using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
}
