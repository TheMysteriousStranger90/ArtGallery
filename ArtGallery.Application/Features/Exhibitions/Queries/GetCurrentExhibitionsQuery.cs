using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Queries;

public class GetCurrentExhibitionsQuery : IRequest<List<ExhibitionDto>>
{
}