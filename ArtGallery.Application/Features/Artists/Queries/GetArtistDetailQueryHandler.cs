using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
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
        var artist = await _unitOfWork.ArtistRepository.GetArtistWithPaintingsAsync(request.Id);

        if (artist == null)
        {
            throw new NotFoundException("Artist not found");
        }

        return _mapper.Map<ArtistDetailDto>(artist);
    }
}
