using FluentValidation;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class AddPaintingToFavoriteCommandValidator : AbstractValidator<AddPaintingToFavoriteCommand>
{
    public AddPaintingToFavoriteCommandValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("User ID is required");

        RuleFor(p => p.PaintingId)
            .NotEmpty().WithMessage("Painting ID is required");
    }
}