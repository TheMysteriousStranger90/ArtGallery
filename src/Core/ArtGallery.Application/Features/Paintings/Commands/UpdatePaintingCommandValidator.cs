using ArtGallery.Application.Contracts;
using ArtGallery.Domain.Entities;
using FluentValidation;

namespace ArtGallery.Application.Features.Paintings.Commands
{
    public class UpdatePaintingCommandValidator : AbstractValidator<UpdatePaintingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public UpdatePaintingCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
                
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("{PropertyName} is required.");
                
            RuleFor(p => p.CreationYear)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("{PropertyName} cannot be in the future.");
                
            RuleFor(p => p.Medium)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
                
            RuleFor(p => p.ArtistId)
                .NotEmpty().WithMessage("Artist is required.")
                .MustAsync(ArtistExists).WithMessage("The specified artist does not exist.");
                
            RuleFor(p => p.GenreId)
                .MustAsync(GenreExistsOrNull).WithMessage("The specified genre does not exist.")
                .When(p => p.GenreId.HasValue);
                
            RuleFor(p => p.MuseumId)
                .MustAsync(MuseumExistsOrNull).WithMessage("The specified museum does not exist.")
                .When(p => p.MuseumId.HasValue);
                
            RuleForEach(p => p.TagIds)
                .MustAsync(TagExists).WithMessage("One or more tags do not exist.")
                .When(p => p.TagIds != null && p.TagIds.Any());
                
            RuleFor(p => p)
                .MustAsync(PaintingExists)
                .WithMessage("The painting with the specified ID does not exist.");
        }
        
        private async Task<bool> PaintingExists(UpdatePaintingCommand command, CancellationToken token)
        {
            return await _unitOfWork.Repository<Painting>().GetByIdAsync(command.Id) != null;
        }
        
        private async Task<bool> ArtistExists(Guid id, CancellationToken token)
        {
            return await _unitOfWork.Repository<Artist>().GetByIdAsync(id) != null;
        }
        
        private async Task<bool> GenreExistsOrNull(Guid? id, CancellationToken token)
        {
            if (!id.HasValue) return true;
            return await _unitOfWork.Repository<Genre>().GetByIdAsync(id.Value) != null;
        }
        
        private async Task<bool> MuseumExistsOrNull(Guid? id, CancellationToken token)
        {
            if (!id.HasValue) return true;
            return await _unitOfWork.Repository<Museum>().GetByIdAsync(id.Value) != null;
        }
        
        private async Task<bool> TagExists(Guid id, CancellationToken token)
        {
            return await _unitOfWork.Repository<Tag>().GetByIdAsync(id) != null;
        }
    }
}