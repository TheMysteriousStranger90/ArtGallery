using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public Guid CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;
    public virtual ICollection<Museum> Museums { get; set; } = new List<Museum>();
}
