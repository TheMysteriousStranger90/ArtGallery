using ArtGallery.Application.DTOs;
using ArtGallery.Domain.Entities;
using ArtGallery.Domain.Entities.Enums;
using FluentAssertions;

namespace ArtGallery.Domain.Tests.Entities;

public class PaintingEntityTests
{
    [Fact]
    public void Painting_DefaultStringProperties_AreEmpty()
    {
        var painting = new Painting();

        painting.Title.Should().Be(string.Empty);
        painting.Medium.Should().Be(string.Empty);
        painting.Dimensions.Should().Be(string.Empty);
        painting.ImageUrl.Should().Be(string.Empty);
    }

    [Fact]
    public void Painting_DefaultCollections_AreNotNull()
    {
        var painting = new Painting();

        painting.Exhibitions.Should().NotBeNull();
        painting.Tags.Should().NotBeNull();
        painting.PaintingImages.Should().NotBeNull();
        painting.UserFavoritePaintings.Should().NotBeNull();
    }

    [Fact]
    public void Painting_WithAssignedProperties_ReturnsCorrectValues()
    {
        var artistId = Guid.NewGuid();
        var painting = new Painting
        {
            Title = "Starry Night",
            Medium = "Oil on canvas",
            CreationYear = 1889,
            PaintType = PaintType.Oil,
            ArtistId = artistId
        };

        painting.Title.Should().Be("Starry Night");
        painting.Medium.Should().Be("Oil on canvas");
        painting.CreationYear.Should().Be(1889);
        painting.PaintType.Should().Be(PaintType.Oil);
        painting.ArtistId.Should().Be(artistId);
    }

    [Fact]
    public void PaintingDto_PaintTypeName_ReturnsEnumName()
    {
        var dto = new PaintingDto { PaintType = PaintType.Oil };

        dto.PaintTypeName.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void Painting_OptionalForeignKeys_CanBeNull()
    {
        var painting = new Painting { Title = "Test" };

        painting.GenreId.Should().BeNull();
        painting.MuseumId.Should().BeNull();
    }
}