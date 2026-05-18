using ArtGallery.Application.Contracts;
using MediatR;

namespace ArtGallery.Application.Features.Tags.Commands;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, DeleteTagCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteTagCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteTagCommandResponse> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var response = new DeleteTagCommandResponse();

        try
        {
            var tag = await _unitOfWork.TagRepository.GetByIdAsync(request.Id);
            if (tag == null)
            {
                response.Success = false;
                response.Message = $"Tag with ID {request.Id} not found";
                return response;
            }

            await _unitOfWork.TagRepository.RemoveAsync(tag);
            response.Message = $"Tag '{tag.Name}' was successfully deleted";
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while deleting the tag: {ex.Message}";
        }

        return response;
    }
}
