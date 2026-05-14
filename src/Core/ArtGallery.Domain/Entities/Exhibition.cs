using ArtGallery.Domain.Common;

namespace ArtGallery.Domain.Entities;

public class Exhibition : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string? ExternalVenueAddress { get; set; } // For exhibitions not in museums

    public Guid? MuseumId { get; set; }
    public virtual Museum Museum { get; set; } = null!;
    public virtual ICollection<PaintingExhibition> Paintings { get; set; } = new List<PaintingExhibition>();
}
