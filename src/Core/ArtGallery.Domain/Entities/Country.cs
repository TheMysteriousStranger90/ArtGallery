using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
