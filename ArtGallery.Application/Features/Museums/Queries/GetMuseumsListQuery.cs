using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Museums.Queries;

public class GetMuseumsListQuery : IRequest<List<MuseumBriefDto>>
{
}
