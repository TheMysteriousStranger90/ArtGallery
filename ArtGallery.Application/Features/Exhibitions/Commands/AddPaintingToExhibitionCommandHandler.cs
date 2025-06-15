using ArtGallery.Application.Contracts;
using ArtGallery.Domain.Entities;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Commands
{
    public class
        AddPaintingToExhibitionCommandHandler : IRequestHandler<AddPaintingToExhibitionCommand,
        ManagePaintingCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPaintingToExhibitionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ManagePaintingCommandResponse> Handle(AddPaintingToExhibitionCommand request,
            CancellationToken cancellationToken)
        {
            var response = new ManagePaintingCommandResponse();

            try
            {
                var exhibition =
                    await _unitOfWork.ExhibitionRepository.GetExhibitionWithPaintingsAsync(request.ExhibitionId);
                if (exhibition == null)
                {
                    response.Success = false;
                    response.Message = $"Exhibition with ID {request.ExhibitionId} not found";
                    return response;
                }

                var painting = await _unitOfWork.Repository<Painting>().GetByIdAsync(request.PaintingId);
                if (painting == null)
                {
                    response.Success = false;
                    response.Message = $"Painting with ID {request.PaintingId} not found";
                    return response;
                }

                var existingRelation = await _unitOfWork.Repository<PaintingExhibition>()
                    .GetByConditionAsync(pe =>
                        pe.ExhibitionId == request.ExhibitionId &&
                        pe.PaintingId == request.PaintingId);

                if (existingRelation != null)
                {
                    response.Success = true;
                    response.Message = "Painting is already part of this exhibition.";
                    return response;
                }

                var paintingExhibition = new PaintingExhibition
                {
                    ExhibitionId = request.ExhibitionId,
                    PaintingId = request.PaintingId
                };

                await _unitOfWork.Repository<PaintingExhibition>().AddAsync(paintingExhibition);
                await _unitOfWork.Complete();

                response.Success = true;
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