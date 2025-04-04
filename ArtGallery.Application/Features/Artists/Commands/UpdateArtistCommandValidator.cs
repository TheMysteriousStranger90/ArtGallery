using FluentValidation;

namespace ArtGallery.Application.Features.Artists.Commands;

public class UpdateArtistCommandValidator : AbstractValidator<UpdateArtistCommand>
{
    public UpdateArtistCommandValidator()
    {
        RuleFor(a => a.Id)
            .NotEmpty().WithMessage("Artist Id is required.");

        RuleFor(a => a.FirstName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(a => a.LastName)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
                
        RuleFor(a => a.Nationality)
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
                
        RuleFor(a => a.BirthDate)
            .LessThan(a => a.DeathDate).When(a => a.DeathDate.HasValue)
            .WithMessage("Birth date must be before death date.");
                
        When(a => a.Biography != null, () =>
        {
            RuleFor(a => a.Biography.ShortDescription)
                .NotEmpty().WithMessage("Biography short description is required.")
                .MaximumLength(500).WithMessage("Biography short description must not exceed 500 characters.");
                    
            RuleFor(a => a.Biography.Content)
                .NotEmpty().WithMessage("Biography content is required.");
        });
    }
}