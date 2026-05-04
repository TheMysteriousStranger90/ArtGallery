using System.ComponentModel.DataAnnotations;
using ArtGallery.ClientApp.Services;

namespace ArtGallery.ClientApp.ViewModels
{
    public class PaintingEditModel
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title must not exceed 200 characters")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        
        [Required(ErrorMessage = "Creation year is required")]
        [Range(1, 2100, ErrorMessage = "Creation year must be between 1 and 2100")]
        public int CreationYear { get; set; }
        
        [Required(ErrorMessage = "Medium is required")]
        [StringLength(100, ErrorMessage = "Medium must not exceed 100 characters")]
        public string Medium { get; set; }
        
        [StringLength(100, ErrorMessage = "Dimensions must not exceed 100 characters")]
        public string Dimensions { get; set; }
        
        public PaintType PaintType { get; set; }
        
        [Required(ErrorMessage = "Artist is required")]
        public Guid ArtistId { get; set; }
        
        public Guid? GenreId { get; set; }
        
        public Guid? MuseumId { get; set; }
        
        public bool KeepExistingImage { get; set; } = true;
    }
}