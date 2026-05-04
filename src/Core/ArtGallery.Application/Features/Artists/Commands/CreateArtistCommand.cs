using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArtGallery.Application.Features.Artists.Commands;

public class CreateArtistCommand : IRequest<CreateArtistCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? DeathDate { get; set; }
    public string Nationality { get; set; }
    public IFormFile Image { get; set; }
    public BiographyCreateDto Biography { get; set; }
        
    public class BiographyCreateDto
    {
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string References { get; set; }
    }
}