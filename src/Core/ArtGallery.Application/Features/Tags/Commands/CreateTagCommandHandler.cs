using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Tags.Commands;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, CreateTagCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateTagCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateTagCommandResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateTagCommandResponse();

        var validator = new CreateTagCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            response.Success = false;
            response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return response;
        }

        try
        {
            var existing = await _unitOfWork.TagRepository.GetTagByNameAsync(request.Name);
            if (existing != null)
            {
                response.Success = false;
                response.Message = $"A tag with the name ''{request.Name}'' already exists";
                return response;
            }

            var tag = new Tag { Name = request.Name.Trim() };
            await _unitOfWork.TagRepository.AddAsync(tag);

            response.Tag = _mapper.Map<TagDto>(tag);
            response.Message = "Tag created successfully";
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while creating the tag: {ex.Message}";
        }

        return response;
    }
}
