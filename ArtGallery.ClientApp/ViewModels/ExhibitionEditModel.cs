using System.ComponentModel.DataAnnotations;

namespace ArtGallery.ClientApp.ViewModels
{
    public class ExhibitionEditModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        public string ExternalVenueAddress { get; set; }

        [Required(ErrorMessage = "Museum is required")]
        public Guid? MuseumId { get; set; }

        public List<Guid> PaintingIds { get; set; } = new List<Guid>();
    }
}