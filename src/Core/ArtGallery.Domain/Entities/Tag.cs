using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Tag : BaseEntity
{
    public string Name { get; set; }

    public virtual ICollection<PaintingTag> Paintings { get; set; } = new List<PaintingTag>();
}