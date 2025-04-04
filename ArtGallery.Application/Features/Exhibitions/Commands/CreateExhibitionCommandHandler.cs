
using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtGallery.Application.Features.Exhibitions.Commands
{
    public class CreateExhibitionCommandHandler : IRequestHandler<CreateExhibitionCommand, CreateExhibitionCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateExhibitionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateExhibitionCommandResponse> Handle(CreateExhibitionCommand request, CancellationToken cancellationToken)
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
                await _unitOfWork.BeginTransactionAsync();
                
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
                
                // Add paintings if any
                int displayOrder = 1;
                foreach (var paintingId in request.PaintingIds)
                {
                    var paintingExhibition = new PaintingExhibition
                    {
                        ExhibitionId = exhibition.Id,
                        PaintingId = paintingId
                    };
                    
                    await _unitOfWork.Repository<PaintingExhibition>().AddAsync(paintingExhibition);
                    displayOrder++;
                }
                
                await _unitOfWork.CommitTransactionAsync();
                
                // Return the newly created exhibition
                var createdExhibition = await _unitOfWork.ExhibitionRepository.GetExhibitionWithPaintingsAsync(exhibition.Id);
                response.Exhibition = _mapper.Map<ExhibitionDto>(createdExhibition);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackTransactionAsync();
                response.Success = false;
                response.Message = $"An error occurred while creating the exhibition: {ex.Message}";
            }
            
            return response;
        }
    }
}