using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Museum : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string? WebsiteUrl { get; set; }

    public Guid CityId { get; set; }

    public virtual City City { get; set; } = null!;
    public virtual ICollection<Painting> Paintings { get; set; } = new List<Painting>();
}
