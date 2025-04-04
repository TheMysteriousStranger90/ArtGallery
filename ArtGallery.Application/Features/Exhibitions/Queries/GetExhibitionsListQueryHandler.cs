using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Queries;

public class GetExhibitionsListQueryHandler : IRequestHandler<GetExhibitionsListQuery, List<ExhibitionDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetExhibitionsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<List<ExhibitionDto>> Handle(GetExhibitionsListQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Exhibition> exhibitions;
            
        if (request.MuseumId.HasValue)
        {
            var spec = new BaseSpecification<Exhibition>(e => e.MuseumId == request.MuseumId.Value);
            spec.AddInclude(e => e.Museum);
            spec.AddInclude(e => e.Museum.City.Country);
            spec.AddOrderBy(e => e.StartDate);
                
            exhibitions = await _unitOfWork.Repository<Exhibition>().ListAsync(spec);
        }
        else
        {
            var spec = new BaseSpecification<Exhibition>();
            spec.AddInclude(e => e.Museum);
            spec.AddInclude(e => e.Museum.City.Country);
            spec.AddOrderBy(e => e.StartDate);
                
            exhibitions = await _unitOfWork.Repository<Exhibition>().ListAsync(spec);
        }
            
        return _mapper.Map<List<ExhibitionDto>>(exhibitions);
    }
}