using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ArtGallery.Application.Features.Exhibitions.Commands
{
    public class
        CreateExhibitionCommandHandler : IRequestHandler<CreateExhibitionCommand, CreateExhibitionCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExhibitionCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            ILogger<CreateExhibitionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<CreateExhibitionCommandResponse> Handle(CreateExhibitionCommand request,
            CancellationToken cancellationToken)
        {
            var response = new CreateExhibitionCommandResponse();

            var validator = new CreateExhibitionCommandValidator(_unitOfWork);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.ValidationErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            try
            {
                Exhibition createdExhibition = null;

                await _unitOfWork.ExecuteWithTransactionAsync(async () =>
                {
                    var exhibition = new Exhibition
                    {
                        Title = request.Title,
                        Description = request.Description,
                        StartDate = request.StartDate,
                        EndDate = request.EndDate,
                        ExternalVenueAddress = request.ExternalVenueAddress,
                        MuseumId = request.MuseumId
                    };

                    await _unitOfWork.Repository<Exhibition>().AddAsync(exhibition);
                    await _unitOfWork.Complete();

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

                        await _unitOfWork.Complete();
                    }

                    createdExhibition = exhibition;
                });

                if (createdExhibition != null)
                {
                    var exhibitionWithDetails = await _unitOfWork.ExhibitionRepository
                        .GetExhibitionWithPaintingsAsync(createdExhibition.Id);

                    response.Exhibition = _mapper.Map<ExhibitionDto>(exhibitionWithDetails);
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"An error occurred while creating the exhibition: {ex.Message}";
            }

            return response;
        }
    }
}