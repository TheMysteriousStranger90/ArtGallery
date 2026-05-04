using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Queries;

public class GetUpcomingExhibitionsQueryHandler : IRequestHandler<GetUpcomingExhibitionsQuery, List<ExhibitionDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetUpcomingExhibitionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ExhibitionDto>> Handle(GetUpcomingExhibitionsQuery request, CancellationToken cancellationToken)
    {
        var exhibitions = await _unitOfWork.ExhibitionRepository.GetUpcomingExhibitionsAsync();
        return _mapper.Map<List<ExhibitionDto>>(exhibitions);
    }
}