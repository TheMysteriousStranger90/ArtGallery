using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Queries;

public class GetPaintingDetailQueryHandler : IRequestHandler<GetPaintingDetailQuery, PaintingDetailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPaintingDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<PaintingDetailDto> Handle(GetPaintingDetailQuery request, CancellationToken cancellationToken)
    {
        var spec = new PaintingSpecification(request.Id);
            
        var painting = await _unitOfWork.Repository<Painting>().GetEntityWithSpec(spec);
            
        if (painting == null)
        {
            throw new Exception(nameof(Painting));
        }
            
        return _mapper.Map<PaintingDetailDto>(painting);
    }
}