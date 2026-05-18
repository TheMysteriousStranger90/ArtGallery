using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Tags.Queries;

public class GetTagDetailQueryHandler : IRequestHandler<GetTagDetailQuery, TagDetailResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetTagDetailQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<TagDetailResponse> Handle(GetTagDetailQuery request, CancellationToken cancellationToken)
    {
        var response = new TagDetailResponse();

        try
        {
            var tag = await _unitOfWork.TagRepository.GetByIdAsync(request.Id);
            if (tag == null)
            {
                response.Success = false;
                response.Message = $"Tag with ID {request.Id} not found";
                return response;
            }

            response.Tag = _mapper.Map<TagDto>(tag);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while retrieving the tag: {ex.Message}";
        }

        return response;
    }
}
