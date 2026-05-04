using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Museum : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string? WebsiteUrl { get; set; }

    public Guid CityId { get; set; }

    public virtual City City { get; set; }
    public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
}