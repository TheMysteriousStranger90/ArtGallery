using FluentValidation;

namespace ArtGallery.Application.Features.Artists.Commands;

public class AddArtistToFavoriteCommandValidator : AbstractValidator<AddArtistToFavoriteCommand>
{
    public AddArtistToFavoriteCommandValidator()
    {
        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("User ID is required");

        RuleFor(p => p.ArtistId)
            .NotEmpty().WithMessage("Artist ID is required");
    }
}