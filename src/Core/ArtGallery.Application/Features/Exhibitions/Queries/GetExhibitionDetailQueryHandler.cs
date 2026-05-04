using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Queries;

public class GetExhibitionDetailQueryHandler : IRequestHandler<GetExhibitionDetailQuery, ExhibitionDetailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetExhibitionDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ExhibitionDetailDto> Handle(GetExhibitionDetailQuery request, CancellationToken cancellationToken)
    {
        var exhibition = await _unitOfWork.ExhibitionRepository.GetExhibitionWithPaintingsAsync(request.Id);
            
        if (exhibition == null)
        {
            throw new Exception(nameof(Exhibition));
        }
            
        return _mapper.Map<ExhibitionDetailDto>(exhibition);
    }
}