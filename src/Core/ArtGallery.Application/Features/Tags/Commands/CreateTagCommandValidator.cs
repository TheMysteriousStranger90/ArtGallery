using FluentValidation;

namespace ArtGallery.Application.Features.Tags.Commands;

public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand>
{
    public CreateTagCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Tag name is required")
            .MaximumLength(50).WithMessage("Tag name must not exceed 50 characters");
    }
}
