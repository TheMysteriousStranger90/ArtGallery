using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Museums.Queries;

public class GetMuseumDetailQueryHandler : IRequestHandler<GetMuseumDetailQuery, MuseumDetailDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetMuseumDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<MuseumDetailDto> Handle(GetMuseumDetailQuery request, CancellationToken cancellationToken)
    {
        var museum = await _unitOfWork.MuseumRepository.GetMuseumWithPaintingsAsync(request.Id);

        if (museum == null)
        {
            throw new NotFoundException("Museum not found");
        }

        return _mapper.Map<MuseumDetailDto>(museum);
    }
}
