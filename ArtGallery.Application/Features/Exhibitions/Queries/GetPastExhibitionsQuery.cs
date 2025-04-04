using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Queries;

public class GetPastExhibitionsQuery : IRequest<List<ExhibitionDto>>
{
}