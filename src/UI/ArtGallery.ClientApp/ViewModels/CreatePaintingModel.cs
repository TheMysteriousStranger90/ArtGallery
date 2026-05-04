using System.ComponentModel.DataAnnotations;
using ArtGallery.ClientApp.Services;

namespace ArtGallery.ClientApp.ViewModels;

public class CreatePaintingModel
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Creation year is required")]
    [Range(1, 2050, ErrorMessage = "Please enter a valid year")]
    public int? CreationYear { get; set; }

    [Required(ErrorMessage = "Medium is required")]
    public string Medium { get; set; }

    [Required(ErrorMessage = "Dimensions are required")]
    public string Dimensions { get; set; }

    [Required(ErrorMessage = "Paint type is required")]
    public PaintType? PaintType { get; set; }

    [Required(ErrorMessage = "Artist is required")]
    public Guid? ArtistId { get; set; }

    public Guid? GenreId { get; set; }

    public Guid? MuseumId { get; set; }
}