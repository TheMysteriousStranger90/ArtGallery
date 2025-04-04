using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Queries;

public class GetArtistDetailQueryHandler : IRequestHandler<GetArtistDetailQuery, ArtistDetailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetArtistDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ArtistDetailDto> Handle(GetArtistDetailQuery request, CancellationToken cancellationToken)
    {
        var spec = new ArtistSpecification(request.Id);
            
        var artist = await _unitOfWork.Repository<Artist>().GetEntityWithSpec(spec);
            
        if (artist == null)
        {
            throw new Exception(nameof(Artist));
        }
            
        return _mapper.Map<ArtistDetailDto>(artist);
    }
}