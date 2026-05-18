using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Tags.Commands;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, UpdateTagCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateTagCommandResponse> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var response = new UpdateTagCommandResponse();

        var validator = new UpdateTagCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        try
        {
            var tag = await _unitOfWork.TagRepository.GetByIdAsync(request.Id);
            if (tag == null)
            {
                response.Success = false;
                response.Message = $"Tag with ID {request.Id} not found";
                return response;
            }

            var existing = await _unitOfWork.TagRepository.GetTagByNameAsync(request.Name);
            if (existing != null && existing.Id != request.Id)
            {
                response.Success = false;
                response.Message = $"A tag with the name ''{request.Name}'' already exists";
                return response;
            }

            tag.Name = request.Name.Trim();
            await _unitOfWork.TagRepository.UpdateAsync(tag);

            response.Tag = _mapper.Map<TagDto>(tag);
            response.Message = "Tag updated successfully";
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while updating the tag: {ex.Message}";
        }

        return response;
    }
}
