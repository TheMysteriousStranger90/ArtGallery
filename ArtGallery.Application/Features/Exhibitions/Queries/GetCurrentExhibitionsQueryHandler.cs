using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Queries;

public class GetCurrentExhibitionsQueryHandler : IRequestHandler<GetCurrentExhibitionsQuery, List<ExhibitionDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetCurrentExhibitionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ExhibitionDto>> Handle(GetCurrentExhibitionsQuery request, CancellationToken cancellationToken)
    {
        var exhibitions = await _unitOfWork.ExhibitionRepository.GetCurrentExhibitionsAsync();
        return _mapper.Map<List<ExhibitionDto>>(exhibitions);
    }
}