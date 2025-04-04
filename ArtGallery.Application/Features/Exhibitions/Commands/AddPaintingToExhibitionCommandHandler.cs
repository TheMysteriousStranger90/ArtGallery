using ArtGallery.Application.Contracts;
using ArtGallery.Application.Exceptions;
using ArtGallery.Domain.Entities;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Commands
{
    public class AddPaintingToExhibitionCommandHandler : IRequestHandler<AddPaintingToExhibitionCommand, ManagePaintingCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPaintingToExhibitionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ManagePaintingCommandResponse> Handle(AddPaintingToExhibitionCommand request, CancellationToken cancellationToken)
        {
            var response = new ManagePaintingCommandResponse();

            try
            {
                // Verify exhibition exists
                var exhibition = await _unitOfWork.Repository<Exhibition>().GetByIdAsync(request.ExhibitionId);
                if (exhibition == null)
                {
                    throw new Exception(nameof(Exhibition));
                }
                
                // Verify painting exists
                var painting = await _unitOfWork.Repository<Painting>().GetByIdAsync(request.PaintingId);
                if (painting == null)
                {
                    throw new Exception(nameof(Painting));
                }
                
                // Check if the relation already exists
                var existingRelation = await _unitOfWork.Repository<PaintingExhibition>()
                    .GetByConditionAsync(pe => 
                        pe.ExhibitionId == request.ExhibitionId && 
                        pe.PaintingId == request.PaintingId);
                
                if (existingRelation != null)
                {
                    response.Message = "Painting is already part of this exhibition.";
                    return response;
                }
                
                // Create the relation
                var paintingExhibition = new PaintingExhibition
                {
                    ExhibitionId = request.ExhibitionId,
                    PaintingId = request.PaintingId
                };
                
                await _unitOfWork.Repository<PaintingExhibition>().AddAsync(paintingExhibition);
                await _unitOfWork.Complete();
                
                response.Message = "Painting successfully added to the exhibition.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while adding painting to exhibition: {ex.Message}";
            }
            
            return response;
        }
    }
}