using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Features.Paintings.Queries;
using ArtGallery.Application.Specifications.Interfaces;
using ArtGallery.Domain.Entities;
using ArtGallery.Domain.Entities.Enums;
using AutoMapper;
using FluentAssertions;
using Moq;

namespace ArtGallery.Application.Tests.Paintings;

public class GetPaintingsListQueryHandlerTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IGenericRepository<Painting>> _mockPaintingRepo;
    private readonly GetPaintingsListQueryHandler _handler;

    public GetPaintingsListQueryHandlerTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _mockPaintingRepo = new Mock<IGenericRepository<Painting>>();

        _mockUnitOfWork.Setup(x => x.Repository<Painting>()).Returns(_mockPaintingRepo.Object);
        _handler = new GetPaintingsListQueryHandler(_mockUnitOfWork.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task Handle_ReturnsCorrectPagination_WhenPaintingsExist()
    {
        // Arrange
        var paintings = new List<Painting>
        {
            new() { Id = Guid.NewGuid(), Title = "Starry Night", CreationYear = 1889, PaintType = PaintType.Oil },
            new() { Id = Guid.NewGuid(), Title = "Sunflowers", CreationYear = 1888, PaintType = PaintType.Oil }
        };
        var dtos = paintings.Select(p => new PaintingDto { Title = p.Title, CreationYear = p.CreationYear }).ToList();

        _mockPaintingRepo.Setup(x => x.ListAsync(It.IsAny<ISpecification<Painting>>()))
            .ReturnsAsync(paintings.AsReadOnly());
        _mockPaintingRepo.Setup(x => x.CountAsync(It.IsAny<ISpecification<Painting>>()))
            .ReturnsAsync(paintings.Count);
        _mockMapper.Setup(x => x.Map<IReadOnlyList<PaintingDto>>(It.IsAny<object>()))
            .Returns(dtos);

        var query = new GetPaintingsListQuery { PageIndex = 1, PageSize = 9 };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(2);
        result.Data.Should().HaveCount(2);
        result.PageIndex.Should().Be(1);
        result.PageSize.Should().Be(9);
    }

    [Fact]
    public async Task Handle_ReturnsEmptyList_WhenNoPaintingsMatch()
    {
        // Arrange
        _mockPaintingRepo.Setup(x => x.ListAsync(It.IsAny<ISpecification<Painting>>()))
            .ReturnsAsync(new List<Painting>().AsReadOnly());
        _mockPaintingRepo.Setup(x => x.CountAsync(It.IsAny<ISpecification<Painting>>()))
            .ReturnsAsync(0);
        _mockMapper.Setup(x => x.Map<IReadOnlyList<PaintingDto>>(It.IsAny<object>()))
            .Returns(new List<PaintingDto>());

        var query = new GetPaintingsListQuery { Search = "nonexistent", PageIndex = 1, PageSize = 9 };

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
        _mockPaintingRepo.Setup(x => x.ListAsync(It.IsAny<ISpecification<Painting>>()))
            .ReturnsAsync(new List<Painting>().AsReadOnly());
        _mockPaintingRepo.Setup(x => x.CountAsync(It.IsAny<ISpecification<Painting>>()))
            .ReturnsAsync(0);
        _mockMapper.Setup(x => x.Map<IReadOnlyList<PaintingDto>>(It.IsAny<object>()))
            .Returns(new List<PaintingDto>());

        var query = new GetPaintingsListQuery { PageIndex = 1, PageSize = 9 };

        // Act
        await _handler.Handle(query, CancellationToken.None);

        // Assert
        _mockPaintingRepo.Verify(x => x.ListAsync(It.IsAny<ISpecification<Painting>>()), Times.Once);
        _mockPaintingRepo.Verify(x => x.CountAsync(It.IsAny<ISpecification<Painting>>()), Times.Once);
    }

    [Fact]
    public async Task Handle_WithYearRange_ReturnsCorrectPagination()
    {
        // Arrange
        var paintings = new List<Painting>
        {
            new() { Id = Guid.NewGuid(), Title = "Impression, Sunrise", CreationYear = 1872 }
        };
        _mockPaintingRepo.Setup(x => x.ListAsync(It.IsAny<ISpecification<Painting>>()))
            .ReturnsAsync(paintings.AsReadOnly());
        _mockPaintingRepo.Setup(x => x.CountAsync(It.IsAny<ISpecification<Painting>>()))
            .ReturnsAsync(1);
        _mockMapper.Setup(x => x.Map<IReadOnlyList<PaintingDto>>(It.IsAny<object>()))
            .Returns(new List<PaintingDto> { new() { Title = "Impression, Sunrise", CreationYear = 1872 } });

        var query = new GetPaintingsListQuery { FromYear = 1870, ToYear = 1880, PageIndex = 1, PageSize = 9 };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        result.Count.Should().Be(1);
        result.Data.Should().ContainSingle(p => p.CreationYear == 1872);
    }
}
