using ArtGallery.Application.Contracts;
using ArtGallery.Application.Exceptions;
using ArtGallery.Domain.Entities;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Commands;

public class RemovePaintingFromExhibitionCommandHandler : IRequestHandler<RemovePaintingFromExhibitionCommand, ManagePaintingCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemovePaintingFromExhibitionCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ManagePaintingCommandResponse> Handle(RemovePaintingFromExhibitionCommand request, CancellationToken cancellationToken)
    {
        var response = new ManagePaintingCommandResponse();

        try
        {
            // Find the relation
            var existingRelation = await _unitOfWork.Repository<PaintingExhibition>()
                .GetByConditionAsync(pe => 
                    pe.ExhibitionId == request.ExhibitionId && 
                    pe.PaintingId == request.PaintingId);
                
            if (existingRelation == null)
            {
                throw new Exception(
                    $"Relation between Exhibition (ID: {request.ExhibitionId}) and Painting (ID: {request.PaintingId})");
            }
                
            // Remove the relation
            await _unitOfWork.Repository<PaintingExhibition>().RemoveAsync(existingRelation);
            await _unitOfWork.Complete();
                
            response.Message = "Painting successfully removed from the exhibition.";
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = $"An error occurred while removing painting from exhibition: {ex.Message}";
        }
            
        return response;
    }
}