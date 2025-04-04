using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Helpers;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Paintings.Queries;

public class GetPaintingsListQueryHandler : IRequestHandler<GetPaintingsListQuery, Pagination<PaintingDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetPaintingsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<Pagination<PaintingDto>> Handle(GetPaintingsListQuery request, CancellationToken cancellationToken)
    {
        var paintingParams = new PaintingSpecParams
        {
            PageIndex = request.PageIndex,
            PageSize = request.PageSize,
            Search = request.Search,
            ArtistId = request.ArtistId,
            GenreId = request.GenreId,
            MuseumId = request.MuseumId,
            PaintType = request.PaintType,
            FromYear = request.FromYear,
            ToYear = request.ToYear,
            Sort = request.Sort
        };
        
        var spec = new PaintingSpecification(paintingParams);
        var countSpec = new PaintingWithFiltersForCountSpecification(paintingParams);
        
        var paintings = await _unitOfWork.Repository<Painting>().ListAsync(spec);
        var totalItems = await _unitOfWork.Repository<Painting>().CountAsync(countSpec);
        
        var paintingDtos = _mapper.Map<IReadOnlyList<PaintingDto>>(paintings);
            
        return new Pagination<PaintingDto>(
            paintingParams.PageIndex,
            paintingParams.PageSize,
            totalItems,
            paintingDtos);
    }
}