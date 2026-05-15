using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Features.Artists.Queries;
using ArtGallery.Application.Specifications.Interfaces;
using ArtGallery.Domain.Entities;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace ArtGallery.Application.Tests.Artists;

public class GetArtistsListQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<Artist>> _mockArtistRepo;
    private readonly GetArtistsListQueryHandler _handler;

    public GetArtistsListQueryHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _mockArtistRepo = new Mock<IGenericRepository<Artist>>();

        _mockUnitOfWork.Setup(x => x.Repository<Artist>()).Returns(_mockArtistRepo.Object);
        _handler = new GetArtistsListQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Handle_ReturnsCorrectPagination_WhenArtistsExist()
    {
        // Arrange
        var artists = new List<Artist>
        {
            new() { Id = Guid.NewGuid(), FirstName = "Vincent", LastName = "van Gogh", Nationality = "Dutch" },
            new() { Id = Guid.NewGuid(), FirstName = "Pablo", LastName = "Picasso", Nationality = "Spanish" }
        };
        var artistDtos = artists.Select(a => new ArtistDto { FirstName = a.FirstName, LastName = a.LastName }).ToList();

        _mockArtistRepo.Setup(x => x.ListAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(artists.AsReadOnly());
        _mockArtistRepo.Setup(x => x.CountAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(artists.Count);
        _mockMapper.Setup(x => x.Map<IReadOnlyList<ArtistDto>>(It.IsAny<object>()))
            .Returns(artistDtos);

        var query = new GetArtistsListQuery { PageIndex = 1, PageSize = 10 };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(2);
        result.Data.Should().HaveCount(2);
        result.PageIndex.Should().Be(1);
        result.PageSize.Should().Be(10);
    }

    [Fact]
    public async Task Handle_ReturnsEmptyList_WhenNoArtistsMatch()
    {
        // Arrange
        _mockArtistRepo.Setup(x => x.ListAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(new List<Artist>().AsReadOnly());
        _mockArtistRepo.Setup(x => x.CountAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(0);
        _mockMapper.Setup(x => x.Map<IReadOnlyList<ArtistDto>>(It.IsAny<object>()))
            .Returns(new List<ArtistDto>());

        var query = new GetArtistsListQuery { Search = "nonexistent", PageIndex = 1, PageSize = 10 };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Count.Should().Be(0);
        result.Data.Should().BeEmpty();
    }

    [Fact]
    public async Task Handle_CallsRepositoryOnce_ForListAndCount()
    {
        // Arrange
        _mockArtistRepo.Setup(x => x.ListAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(new List<Artist>().AsReadOnly());
        _mockArtistRepo.Setup(x => x.CountAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(0);
        _mockMapper.Setup(x => x.Map<IReadOnlyList<ArtistDto>>(It.IsAny<object>()))
            .Returns(new List<ArtistDto>());

        var query = new GetArtistsListQuery { PageIndex = 1, PageSize = 10 };

        // Act
        await _handler.Handle(query, CancellationToken.None);

        // Assert
        _mockArtistRepo.Verify(x => x.ListAsync(It.IsAny<ISpecification<Artist>>()), Times.Once);
        _mockArtistRepo.Verify(x => x.CountAsync(It.IsAny<ISpecification<Artist>>()), Times.Once);
    }

    [Fact]
    public async Task Handle_WithPagination_ReturnsCorrectPageMetadata()
    {
        // Arrange
        _mockArtistRepo.Setup(x => x.ListAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(new List<Artist>().AsReadOnly());
        _mockArtistRepo.Setup(x => x.CountAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(50);
        _mockMapper.Setup(x => x.Map<IReadOnlyList<ArtistDto>>(It.IsAny<object>()))
            .Returns(new List<ArtistDto>());

        var query = new GetArtistsListQuery { PageIndex = 3, PageSize = 10 };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.PageIndex.Should().Be(3);
        result.PageSize.Should().Be(10);
        result.Count.Should().Be(50);
    }

    [Fact]
    public async Task Handle_MapsArtistsToDto_UsingMapper()
    {
        // Arrange
        var artists = new List<Artist>
        {
            new() { Id = Guid.NewGuid(), FirstName = "Claude", LastName = "Monet" }
        };
        var expectedDto = new ArtistDto { FirstName = "Claude", LastName = "Monet" };

        _mockArtistRepo.Setup(x => x.ListAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(artists.AsReadOnly());
        _mockArtistRepo.Setup(x => x.CountAsync(It.IsAny<ISpecification<Artist>>()))
            .ReturnsAsync(1);
        _mockMapper.Setup(x => x.Map<IReadOnlyList<ArtistDto>>(It.IsAny<object>()))
            .Returns(new List<ArtistDto> { expectedDto });

        var query = new GetArtistsListQuery { PageIndex = 1, PageSize = 10 };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        _mockMapper.Verify(x => x.Map<IReadOnlyList<ArtistDto>>(It.IsAny<object>()), Times.Once);
        result.Data.Should().ContainSingle(d => d.FirstName == "Claude" && d.LastName == "Monet");
    }
}