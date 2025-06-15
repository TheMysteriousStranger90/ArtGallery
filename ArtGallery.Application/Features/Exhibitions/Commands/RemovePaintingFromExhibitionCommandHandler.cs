using ArtGallery.Application.Contracts;
using ArtGallery.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArtGallery.Application.Features.Exhibitions.Commands
{
    public class RemovePaintingFromExhibitionCommandHandler : IRequestHandler<RemovePaintingFromExhibitionCommand, ManagePaintingCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemovePaintingFromExhibitionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ManagePaintingCommandResponse> Handle(RemovePaintingFromExhibitionCommand request, CancellationToken cancellationToken)
        {
            var response = new ManagePaintingCommandResponse();

            try
            {
                // Validate exhibition exists
                var exhibition = await _unitOfWork.Repository<Exhibition>().GetByIdAsync(request.ExhibitionId);
                if (exhibition == null)
                {
                    response.Success = false;
                    response.Message = $"Exhibition with ID {request.ExhibitionId} not found";
                    return response;
                }

                // Validate painting exists
                var painting = await _unitOfWork.Repository<Painting>().GetByIdAsync(request.PaintingId);
                if (painting == null)
                {
                    response.Success = false;
                    response.Message = $"Painting with ID {request.PaintingId} not found";
                    return response;
                }

                // Find the relation
                var existingRelation = await _unitOfWork.Repository<PaintingExhibition>()
                    .GetByConditionAsync(pe => 
                        pe.ExhibitionId == request.ExhibitionId && 
                        pe.PaintingId == request.PaintingId);
                    
                if (existingRelation == null)
                {
                    response.Success = false;
                    response.Message = $"Painting with ID {request.PaintingId} is not part of exhibition with ID {request.ExhibitionId}";
                    return response;
                }
                    
                await _unitOfWork.ExecuteWithTransactionAsync(async () =>
                {
                    await _unitOfWork.Repository<PaintingExhibition>().RemoveAsync(existingRelation);
                    await _unitOfWork.Complete();
                });
                    
                response.Success = true;
                response.Message = $"Painting '{painting.Title}' was successfully removed from exhibition '{exhibition.Title}'.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while removing painting from exhibition: {ex.Message}";
            }
                
            return response;
        }
    }
}