using FluentValidation;

namespace ArtGallery.Application.Features.Users.Commands
{
    public class RemoveRoleCommandValidator : AbstractValidator<RemoveRoleCommand>
    {
        public RemoveRoleCommandValidator()
        {
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("User ID is required");

            RuleFor(p => p.RoleName)
                .NotEmpty().WithMessage("Role name is required")
                .MaximumLength(50).WithMessage("Role name must not exceed 50 characters");
        }
    }
}