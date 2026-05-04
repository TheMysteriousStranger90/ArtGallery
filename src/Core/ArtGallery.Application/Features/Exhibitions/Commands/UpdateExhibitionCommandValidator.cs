using ArtGallery.Application.Contracts;
using ArtGallery.Domain.Entities;
using FluentValidation;

namespace ArtGallery.Application.Features.Exhibitions.Commands
{
    public class UpdateExhibitionCommandValidator : AbstractValidator<UpdateExhibitionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UpdateExhibitionCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
            RuleFor(e => e.Id)
                .NotEmpty().WithMessage("Exhibition ID is required.");
                
            RuleFor(e => e.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
                
            RuleFor(e => e.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.");
                
            RuleFor(e => e.StartDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeAValidDate).WithMessage("{PropertyName} must be a valid date.");
                
            RuleFor(e => e.EndDate)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .Must(BeAValidDate).WithMessage("{PropertyName} must be a valid date.")
                .GreaterThanOrEqualTo(e => e.StartDate).WithMessage("{PropertyName} must be after or equal to the start date.");
                
            RuleFor(e => e)
                .Must(e => !string.IsNullOrEmpty(e.ExternalVenueAddress) || e.MuseumId.HasValue)
                .WithMessage("Either Museum or External Venue Address must be specified.");
                
            RuleFor(e => e.MuseumId)
                .MustAsync(MuseumExistsOrNull).WithMessage("The specified museum does not exist.")
                .When(e => e.MuseumId.HasValue);
                
            RuleForEach(e => e.PaintingIds)
                .MustAsync(PaintingExists).WithMessage("One or more paintings do not exist.");
                
            RuleFor(e => e)
                .MustAsync(ExhibitionExists)
                .WithMessage("The exhibition with the specified ID does not exist.");
        }
        
        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default);
        }
        
        private async Task<bool> ExhibitionExists(UpdateExhibitionCommand command, CancellationToken token)
        {
            return await _unitOfWork.Repository<Exhibition>().GetByIdAsync(command.Id) != null;
        }
        
        private async Task<bool> MuseumExistsOrNull(Guid? id, CancellationToken token)
        {
            if (!id.HasValue) return true;
            return await _unitOfWork.Repository<Museum>().GetByIdAsync(id.Value) != null;
        }
        
        private async Task<bool> PaintingExists(Guid id, CancellationToken token)
        {
            return await _unitOfWork.Repository<Painting>().GetByIdAsync(id) != null;
        }
    }
}