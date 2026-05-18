using FluentValidation;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class RemovePaintingFromFavoriteCommandValidator : AbstractValidator<RemovePaintingFromFavoriteCommand>
{
    public RemovePaintingFromFavoriteCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty().WithMessage("User ID is required");
        RuleFor(p => p.PaintingId).NotEmpty().WithMessage("Painting ID is required");
    }
}
