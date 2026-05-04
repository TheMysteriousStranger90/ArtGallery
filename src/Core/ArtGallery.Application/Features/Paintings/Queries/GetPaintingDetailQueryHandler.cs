using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
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
        var painting = await _unitOfWork.PaintingRepository.GetPaintingWithDetailsAsync(request.Id);

        if (painting == null)
        {
            throw new NotFoundException("Painting not found");
        }

        return _mapper.Map<PaintingDetailDto>(painting);
    }
}
