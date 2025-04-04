using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArtGallery.Application.Features.Artists.Commands;

public class UpdateArtistCommand : IRequest<UpdateArtistCommandResponse>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string Nationality { get; set; }
    public IFormFile Image { get; set; }
    public bool KeepExistingImage { get; set; } = true;
    public BiographyUpdateDto Biography { get; set; }
        
    public class BiographyUpdateDto
    {
        public Guid? Id { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string References { get; set; }
    }
}