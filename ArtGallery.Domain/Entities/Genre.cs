using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Genre : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    
    public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
}