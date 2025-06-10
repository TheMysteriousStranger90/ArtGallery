using ArtGallery.Application.Models.Authentication;
using MediatR;

namespace ArtGallery.Application.Features.Authentication.Commands
{
    public class ExternalAuthCommand : IRequest<ExternalAuthResponse>
    {
        public string Provider { get; set; }
        public string IdToken { get; set; }
        public string AccessToken { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ExternalId { get; set; }
    }
}