using FluentValidation;

namespace ArtGallery.Application.Features.Tags.Commands;

public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand>
{
    public UpdateTagCommandValidator()
    {
        RuleFor(p => p.Id).NotEmpty().WithMessage("Tag ID is required");
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Tag name is required")
            .MaximumLength(50).WithMessage("Tag name must not exceed 50 characters");
    }
}
