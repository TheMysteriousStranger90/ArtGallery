using ArtGallery.Application.DTOs;
using ArtGallery.Domain.Entities;
using FluentAssertions;

namespace ArtGallery.Domain.Tests.Entities;

public class ArtistEntityTests
{
    [Fact]
    public void Artist_DefaultCollections_AreNotNull()
    {
        var artist = new Artist();

        artist.ArtistImage.Should().NotBeNull();
        artist.Paintings.Should().NotBeNull();
        artist.UserFavoriteArtists.Should().NotBeNull();
    }

    [Fact]
    public void Artist_DefaultStringProperties_AreEmpty()
    {
        var artist = new Artist();

        artist.FirstName.Should().Be(string.Empty);
        artist.LastName.Should().Be(string.Empty);
        artist.Nationality.Should().Be(string.Empty);
    }

    [Fact]
    public void Artist_WithAssignedName_ReturnsCorrectValues()
    {
        var artist = new Artist
        {
            FirstName = "Vincent",
            LastName = "van Gogh",
            Nationality = "Dutch"
        };

        artist.FirstName.Should().Be("Vincent");
        artist.LastName.Should().Be("van Gogh");
        artist.Nationality.Should().Be("Dutch");
    }

    [Fact]
    public void Artist_WithDates_StoresDatesCorrectly()
    {
        var birthDate = new DateTime(1853, 3, 30);
        var deathDate = new DateTime(1890, 7, 29);

        var artist = new Artist
        {
            FirstName = "Vincent",
            LastName = "van Gogh",
            BirthDate = birthDate,
            DeathDate = deathDate
        };

        artist.BirthDate.Should().Be(birthDate);
        artist.DeathDate.Should().Be(deathDate);
    }

    [Fact]
    public void ArtistDto_FullName_CombinesFirstAndLastName()
    {
        var dto = new ArtistDto { FirstName = "Vincent", LastName = "van Gogh" };

        dto.FullName.Should().Be("Vincent van Gogh");
    }

    [Fact]
    public void ArtistDto_FullName_WithNullFirstName_DoesNotThrow()
    {
        var dto = new ArtistDto { FirstName = null, LastName = "van Gogh" };

        var act = () => dto.FullName;

        act.Should().NotThrow();
        dto.FullName.Should().Contain("van Gogh");
    }
}