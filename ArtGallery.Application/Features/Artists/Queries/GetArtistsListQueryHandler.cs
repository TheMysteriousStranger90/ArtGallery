using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Helpers;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Queries;

public class GetArtistsListQueryHandler : IRequestHandler<GetArtistsListQuery, Pagination<ArtistDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetArtistsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Pagination<ArtistDto>> Handle(GetArtistsListQuery request, CancellationToken cancellationToken)
    {
        var artistParams = new ArtistSpecParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            Sort = request.Sort,
            Nationality = request.Nationality
        };
        
        var spec = new ArtistSpecification(artistParams);
        var countSpec = new ArtistWithFiltersForCountSpecification(artistParams);
            
        var artists = await _unitOfWork.Repository<Artist>().ListAsync(spec);
        var totalItems = await _unitOfWork.Repository<Artist>().CountAsync(countSpec);
            
        var artistDtos = _mapper.Map<IReadOnlyList<ArtistDto>>(artists);
            
        return new Pagination<ArtistDto>(
            artistParams.PageIndex,
            artistParams.PageSize,
            totalItems,
            artistDtos);
    }
}