using ArtGallery.Application.DTOs;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Queries;

public class GetPaintingDetailQuery : IRequest<PaintingDetailDto>
{
    public Guid Id { get; set; }
}