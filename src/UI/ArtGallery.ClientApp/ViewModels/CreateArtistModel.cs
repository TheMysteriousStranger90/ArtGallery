using System.ComponentModel.DataAnnotations;

namespace ArtGallery.ClientApp.ViewModels;


public class CreateArtistModel
{
    [Required(ErrorMessage = "First name is required")]
    [StringLength(100, ErrorMessage = "First name must not exceed 100 characters")]
    public string FirstName { get; set; }
        
    [Required(ErrorMessage = "Last name is required")]
    [StringLength(100, ErrorMessage = "Last name must not exceed 100 characters")]
    public string LastName { get; set; }
        
    public DateTimeOffset? BirthDate { get; set; }
        
    public DateTimeOffset? DeathDate { get; set; }
        
    [StringLength(100, ErrorMessage = "Nationality must not exceed 100 characters")]
    public string Nationality { get; set; }
        
    [StringLength(500, ErrorMessage = "Short description must not exceed 500 characters")]
    public string BiographyShortDescription { get; set; }
        
    public string BiographyContent { get; set; }
        
    public string BiographyReferences { get; set; }
}