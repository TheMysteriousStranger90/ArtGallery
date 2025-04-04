using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; }
    public string Code { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}