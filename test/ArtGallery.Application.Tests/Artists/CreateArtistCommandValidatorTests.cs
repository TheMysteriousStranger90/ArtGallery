using ArtGallery.Application.Features.Artists.Commands;
using FluentAssertions;

namespace ArtGallery.Application.Tests.Artists;

public class CreateArtistCommandValidatorTests
{
    private readonly CreateArtistCommandValidator _validator = new();

    [Fact]
    public async Task Validate_WithValidCommand_PassesValidation()
    {
        var command = new CreateArtistCommand
        {
            FirstName = "Claude",
            LastName = "Monet",
            Nationality = "French",
            BirthDate = new DateTime(1840, 11, 14)
        };

        var result = await _validator.ValidateAsync(command);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public async Task Validate_WithEmptyFirstName_FailsValidation()
    {
        var command = new CreateArtistCommand { FirstName = "", LastName = "Monet" };

        var result = await _validator.ValidateAsync(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateArtistCommand.FirstName));
    }

    [Fact]
    public async Task Validate_WithEmptyLastName_FailsValidation()
    {
        var command = new CreateArtistCommand { FirstName = "Claude", LastName = "" };

        var result = await _validator.ValidateAsync(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateArtistCommand.LastName));
    }

    [Fact]
    public async Task Validate_WithFirstNameExceedingMaxLength_FailsValidation()
    {
        var command = new CreateArtistCommand
        {
            FirstName = new string('A', 101),
            LastName = "Monet"
        };

        var result = await _validator.ValidateAsync(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateArtistCommand.FirstName));
    }

    [Fact]
    public async Task Validate_WithBirthDateAfterDeathDate_FailsValidation()
    {
        var command = new CreateArtistCommand
        {
            FirstName = "Claude",
            LastName = "Monet",
            BirthDate = new DateTime(1926, 12, 5),
            DeathDate = new DateTime(1840, 11, 14)
        };

        var result = await _validator.ValidateAsync(command);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(e => e.PropertyName == nameof(CreateArtistCommand.BirthDate));
    }

    [Fact]
    public async Task Validate_WithNullBiography_PassesValidation()
    {
        var command = new CreateArtistCommand
        {
            FirstName = "Vincent",
            LastName = "van Gogh",
            Biography = null
        };

        var result = await _validator.ValidateAsync(command);

        result.IsValid.Should().BeTrue();
    }
}