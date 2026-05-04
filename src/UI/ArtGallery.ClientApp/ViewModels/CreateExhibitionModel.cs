using System.ComponentModel.DataAnnotations;

namespace ArtGallery.ClientApp.ViewModels;

public class CreateExhibitionModel
{
    [Required(ErrorMessage = "Exhibition title is required")]
    [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required")]
    [StringLength(2000, ErrorMessage = "Description cannot exceed 2000 characters")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Start date is required")]
    public DateTime StartDate { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "End date is required")]
    public DateTime EndDate { get; set; } = DateTime.Today.AddDays(30);

    [StringLength(500, ErrorMessage = "External venue address cannot exceed 500 characters")]
    public string? ExternalVenueAddress { get; set; }

    public Guid? MuseumId { get; set; }

    public HashSet<Guid> PaintingIds { get; set; } = new();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndDate <= StartDate)
        {
            yield return new ValidationResult("End date must be after start date", new[] { nameof(EndDate) });
        }

        if (StartDate < DateTime.Today.AddDays(-1))
        {
            yield return new ValidationResult("Start date cannot be in the past", new[] { nameof(StartDate) });
        }
    }
}