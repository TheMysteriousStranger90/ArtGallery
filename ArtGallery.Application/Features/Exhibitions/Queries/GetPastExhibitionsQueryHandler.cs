using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Queries;

public class GetPastExhibitionsQueryHandler : IRequestHandler<GetPastExhibitionsQuery, List<ExhibitionDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPastExhibitionsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ExhibitionDto>> Handle(GetPastExhibitionsQuery request, CancellationToken cancellationToken)
    {
        var exhibitions = await _unitOfWork.ExhibitionRepository.GetPastExhibitionsAsync();
        return _mapper.Map<List<ExhibitionDto>>(exhibitions);
    }
}