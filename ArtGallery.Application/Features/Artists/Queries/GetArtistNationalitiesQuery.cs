using MediatR;

namespace ArtGallery.Application.Features.Artists.Queries;

public class GetArtistNationalitiesQuery : IRequest<List<string>>
{
}