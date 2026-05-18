using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Tags.Queries;

public class GetTagsListQueryHandler : IRequestHandler<GetTagsListQuery, TagsListResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTagsListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TagsListResponse> Handle(GetTagsListQuery request, CancellationToken cancellationToken)
    {
        var response = new TagsListResponse();

        try
        {
            var tags = await _unitOfWork.TagRepository.GetAllTagsAsync();
            response.Tags = _mapper.Map<List<TagDto>>(tags);
            response.Count = response.Tags.Count;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while retrieving tags: {ex.Message}";
        }

        return response;
    }
}
