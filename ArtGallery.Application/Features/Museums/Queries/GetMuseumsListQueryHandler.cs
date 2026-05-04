using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Museums.Queries;

public class GetMuseumsListQueryHandler : IRequestHandler<GetMuseumsListQuery, List<MuseumBriefDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMuseumsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<MuseumBriefDto>> Handle(GetMuseumsListQuery request, CancellationToken cancellationToken)
    {
        var spec = new BaseSpecification<Museum>();
        spec.AddInclude(m => m.City);
        spec.AddOrderBy(m => m.Name);

        var museums = await _unitOfWork.MuseumRepository.ListAsync(spec);
        return _mapper.Map<List<MuseumBriefDto>>(museums);
    }
}
