using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }

    public Guid CountryId { get; set; }

    public virtual Country Country { get; set; }
    public virtual ICollection<Museum> Museums { get; set; } = new List<Museum>();
}