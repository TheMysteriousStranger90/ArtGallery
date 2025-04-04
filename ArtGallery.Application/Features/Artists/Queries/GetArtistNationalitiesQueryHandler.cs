using ArtGallery.Application.Contracts;
using MediatR;

namespace ArtGallery.Application.Features.Artists.Queries;

public class GetArtistNationalitiesQueryHandler : IRequestHandler<GetArtistNationalitiesQuery, List<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetArtistNationalitiesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<string>> Handle(GetArtistNationalitiesQuery request, CancellationToken cancellationToken)
    {
        var nationalities = await _unitOfWork.ArtistRepository.GetAllNationalitiesAsync();
        return nationalities.ToList();
    }
}