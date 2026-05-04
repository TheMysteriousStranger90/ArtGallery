using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Specifications;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Commands
{
    public class
        UpdateExhibitionCommandHandler : IRequestHandler<UpdateExhibitionCommand, UpdateExhibitionCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExhibitionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UpdateExhibitionCommandResponse> Handle(UpdateExhibitionCommand request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateExhibitionCommandResponse();

            var validator = new UpdateExhibitionCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            try
            {
                await _unitOfWork.ExecuteWithTransactionAsync(async () =>
                {
                    var exhibition = await _unitOfWork.Repository<Exhibition>().GetByIdAsync(request.Id);

                    if (exhibition == null)
                    {
                        throw new Exception($"Exhibition with ID {request.Id} not found");
                    }

                    exhibition.Title = request.Title;
                    exhibition.Description = request.Description;
                    exhibition.StartDate = request.StartDate;
                    exhibition.EndDate = request.EndDate;
                    exhibition.ExternalVenueAddress = request.ExternalVenueAddress;
                    exhibition.MuseumId = request.MuseumId;

                    await _unitOfWork.Repository<Exhibition>().UpdateAsync(exhibition);

                    var existingPaintings = await _unitOfWork.Repository<PaintingExhibition>()
                        .ListAsync(new BaseSpecification<PaintingExhibition>(pe => pe.ExhibitionId == request.Id));

                    foreach (var paintingExhibition in existingPaintings)
                    {
                        await _unitOfWork.Repository<PaintingExhibition>().RemoveAsync(paintingExhibition);
                    }

                    if (request.PaintingIds?.Any() == true)
                    {
                        foreach (var paintingId in request.PaintingIds)
                        {
                            var paintingExhibition = new PaintingExhibition
                            {
                                ExhibitionId = exhibition.Id,
                                PaintingId = paintingId,
                            };

                            await _unitOfWork.Repository<PaintingExhibition>().AddAsync(paintingExhibition);
                        }
                    }

                    await _unitOfWork.Complete();
                });

                var updatedExhibition =
                    await _unitOfWork.ExhibitionRepository.GetExhibitionWithPaintingsAsync(request.Id);
                if (updatedExhibition != null)
                {
                    response.Exhibition = _mapper.Map<ExhibitionDto>(updatedExhibition);
                    response.Message = "Exhibition updated successfully.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Exhibition was updated but could not be retrieved.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while updating the exhibition: {ex.Message}";
            }

            return response;
        }
    }
}