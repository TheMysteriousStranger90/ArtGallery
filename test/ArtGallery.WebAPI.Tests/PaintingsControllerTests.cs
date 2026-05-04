using System.Security.Claims;
using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Features.Paintings.Commands;
using ArtGallery.Application.Features.Paintings.Queries;
using ArtGallery.Application.Helpers;
using ArtGallery.Domain.Entities;
using ArtGallery.WebAPI.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;

namespace ArtGallery.WebAPI.Tests
{
    public class PaintingsControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly Mock<ILogger<PaintingsController>> _mockLogger;
        private readonly Mock<IMemoryCache> _mockMemoryCache;
        private readonly Mock<ICacheKeyService> _mockCacheKeyService;
        private readonly PaintingsController _controller;

        public PaintingsControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _mockLogger = new Mock<ILogger<PaintingsController>>();
            _mockMemoryCache = new Mock<IMemoryCache>();
            _mockCacheKeyService = new Mock<ICacheKeyService>();

            // Set up common memory cache mock behavior
            var cacheEntry = new Mock<ICacheEntry>();
            _mockMemoryCache.Setup(m => m.CreateEntry(It.IsAny<object>()))
                .Returns(cacheEntry.Object);

            _controller = new PaintingsController(
                _mockMediator.Object,
                _mockLogger.Object,
                _mockMemoryCache.Object,
                _mockCacheKeyService.Object
            );
        }

        #region GetPaintings

        [Fact]
        public async Task GetPaintings_ReturnsFromCache_WhenCacheHit()
        {
            // Arrange
            var cachedPaintings = new Pagination<PaintingDto>(
                pageIndex: 1,
                pageSize: 9,
                count: 2,
                data: new List<PaintingDto>
                {
                    new PaintingDto { Id = Guid.NewGuid(), Title = "Starry Night" },
                    new PaintingDto { Id = Guid.NewGuid(), Title = "Sunflowers" }
                }
            );

            object expectedValue = cachedPaintings;
            _mockMemoryCache
                .Setup(m => m.TryGetValue(It.IsAny<string>(), out expectedValue))
                .Returns(true);

            // Act
            var result = await _controller.GetPaintings();

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<Pagination<PaintingDto>>().Subject;
            returnValue.Data.Should().HaveCount(2);

            // Verify mediator was not called since we got result from cache
            _mockMediator.Verify(m => m.Send(It.IsAny<GetPaintingsListQuery>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetPaintings_FetchesFromDatabase_WhenCacheMiss()
        {
            // Arrange
            object expectedValue = null;
            _mockMemoryCache
                .Setup(m => m.TryGetValue(It.IsAny<string>(), out expectedValue))
                .Returns(false);

            var paintingsResult = new Pagination<PaintingDto>(
                pageIndex: 1,
                pageSize: 9,
                count: 2,
                data: new List<PaintingDto>
                {
                    new PaintingDto { Id = Guid.NewGuid(), Title = "Starry Night" },
                    new PaintingDto { Id = Guid.NewGuid(), Title = "Sunflowers" }
                }
            );

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetPaintingsListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(paintingsResult);

            // Act
            var result = await _controller.GetPaintings(
                pageIndex: 1,
                pageSize: 9,
                search: "test",
                artistId: Guid.NewGuid(),
                sort: "title");

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<Pagination<PaintingDto>>().Subject;
            returnValue.Data.Should().HaveCount(2);

            // Verify mediator was called to fetch data
            _mockMediator.Verify(m => m.Send(It.IsAny<GetPaintingsListQuery>(),
                It.IsAny<CancellationToken>()), Times.Once);

            // Verify cache was updated
            _mockCacheKeyService.Verify(c => c.AddKey(It.IsAny<string>()), Times.Once);
        }

        #endregion

        #region GetPainting

        [Fact]
        public async Task GetPainting_ReturnsFromCache_WhenCacheHit()
        {
            // Arrange
            var paintingId = Guid.NewGuid();
            var cachedPainting = new PaintingDetailDto
            {
                Id = paintingId,
                Title = "Starry Night",
                Description = "A famous painting"
            };

            object expectedValue = cachedPainting;
            _mockMemoryCache
                .Setup(m => m.TryGetValue(It.IsAny<string>(), out expectedValue))
                .Returns(true);

            // Act
            var result = await _controller.GetPainting(paintingId);

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<PaintingDetailDto>().Subject;
            returnValue.Id.Should().Be(paintingId);

            // Verify mediator was not called
            _mockMediator.Verify(m => m.Send(It.IsAny<GetPaintingDetailQuery>(),
                It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task GetPainting_FetchesFromDatabase_WhenCacheMiss()
        {
            // Arrange
            var paintingId = Guid.NewGuid();
            var paintingDetail = new PaintingDetailDto
            {
                Id = paintingId,
                Title = "Starry Night",
                Description = "A famous painting"
            };

            object expectedValue = null;
            _mockMemoryCache
                .Setup(m => m.TryGetValue(It.IsAny<string>(), out expectedValue))
                .Returns(false);

            _mockMediator
                .Setup(m => m.Send(It.Is<GetPaintingDetailQuery>(q => q.Id == paintingId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(paintingDetail);

            // Act
            var result = await _controller.GetPainting(paintingId);

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<PaintingDetailDto>().Subject;
            returnValue.Id.Should().Be(paintingId);

            // Verify mediator was called
            _mockMediator.Verify(m => m.Send(It.IsAny<GetPaintingDetailQuery>(),
                It.IsAny<CancellationToken>()), Times.Once);

            // Verify cache was updated
            _mockCacheKeyService.Verify(c => c.AddKey(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task GetPainting_ThrowsNotFoundException_WhenPaintingNotFound()
        {
            // Arrange
            var paintingId = Guid.NewGuid();

            object expectedValue = null;
            _mockMemoryCache
                .Setup(m => m.TryGetValue(It.IsAny<string>(), out expectedValue))
                .Returns(false);

            _mockMediator
                .Setup(m => m.Send(It.Is<GetPaintingDetailQuery>(q => q.Id == paintingId),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception(nameof(Painting)));

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(
                () => _controller.GetPainting(paintingId));
        }

        #endregion

        #region CreatePainting

        [Fact]
        public async Task CreatePainting_ReturnsCreatedResult_WhenValidCommand()
        {
            // Arrange
            var paintingId = Guid.NewGuid();
            var command = new CreatePaintingCommand
            {
                Title = "New Painting",
                Description = "A new painting",
                ArtistId = Guid.NewGuid()
            };

            var response = new CreatePaintingCommandResponse
            {
                Success = true,
                Painting = new PaintingDto
                {
                    Id = paintingId,
                    Title = "New Painting"
                }
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            _mockCacheKeyService
                .Setup(c => c.GetKeysStartingWith(It.IsAny<string>()))
                .Returns(new List<string> { "Paintings_1", "Paintings_Detail_123" });

            // Act
            var result = await _controller.CreatePainting(command);

            // Assert
            var createdAtResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
            createdAtResult.ActionName.Should().Be(nameof(PaintingsController.GetPainting));
            createdAtResult.RouteValues["id"].Should().Be(paintingId);

            var returnValue = createdAtResult.Value.Should().BeAssignableTo<PaintingDto>().Subject;
            returnValue.Id.Should().Be(paintingId);

            // Verify cache was invalidated
            _mockCacheKeyService.Verify(c => c.GetKeysStartingWith("Paintings"), Times.Once);
            _mockMemoryCache.Verify(m => m.Remove(It.IsAny<string>()), Times.AtLeast(1));
        }

        [Fact]
        public async Task CreatePainting_ReturnsBadRequest_WhenInvalidCommand()
        {
            // Arrange
            var command = new CreatePaintingCommand
            {
                // Missing required fields
            };

            var response = new CreatePaintingCommandResponse
            {
                Success = false,
                ValidationErrors = new List<string> { "Title is required" }
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.CreatePainting(command);

            // Assert
            var badRequestResult = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
            var validationProblems = badRequestResult.Value.Should().BeAssignableTo<ValidationProblemDetails>().Subject;
            validationProblems.Errors.Should().ContainKey("Validation");
        }

        #endregion

        #region UpdatePainting

        [Fact]
        public async Task UpdatePainting_ReturnsOkResult_WhenValidCommand()
        {
            // Arrange
            var paintingId = Guid.NewGuid();
            var command = new UpdatePaintingCommand
            {
                Id = paintingId,
                Title = "Updated Painting",
                Description = "An updated painting"
            };

            var response = new UpdatePaintingCommandResponse
            {
                Success = true,
                Painting = new PaintingDto
                {
                    Id = paintingId,
                    Title = "Updated Painting"
                }
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            _mockCacheKeyService
                .Setup(c => c.GetKeysStartingWith(It.IsAny<string>()))
                .Returns(new List<string> { "Paintings_1", "Paintings_Detail_123" });

            // Act
            var result = await _controller.UpdatePainting(paintingId, command);

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<PaintingDto>().Subject;
            returnValue.Id.Should().Be(paintingId);

            // Verify cache was invalidated
            _mockCacheKeyService.Verify(c => c.GetKeysStartingWith("Paintings"), Times.Once);
            _mockMemoryCache.Verify(m => m.Remove(It.IsAny<string>()), Times.AtLeast(1));
        }

        [Fact]
        public async Task UpdatePainting_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var paintingId = Guid.NewGuid();
            var differentId = Guid.NewGuid();
            var command = new UpdatePaintingCommand
            {
                Id = differentId,
                Title = "Updated Painting"
            };

            // Act
            var result = await _controller.UpdatePainting(paintingId, command);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task UpdatePainting_ThrowsNotFoundException_WhenPaintingNotFound()
        {
            // Arrange
            var paintingId = Guid.NewGuid();
            var command = new UpdatePaintingCommand
            {
                Id = paintingId,
                Title = "Updated Painting"
            };

            var response = new UpdatePaintingCommandResponse
            {
                Success = false,
                Message = $"{nameof(Painting)} not found"
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(
                () => _controller.UpdatePainting(paintingId, command));
        }

        #endregion

        #region DeletePainting

        [Fact]
        public async Task DeletePainting_ReturnsOkResult_WhenValidId()
        {
            // Arrange
            var paintingId = Guid.NewGuid();

            var response = new DeletePaintingCommandResponse
            {
                Success = true,
                Message = "Painting deleted successfully"
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<DeletePaintingCommand>(c => c.Id == paintingId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            _mockCacheKeyService
                .Setup(c => c.GetKeysStartingWith(It.IsAny<string>()))
                .Returns(new List<string> { "Paintings_1", "Paintings_Detail_123" });

            // Act
            var result = await _controller.DeletePainting(paintingId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();

            // Verify cache was invalidated
            _mockCacheKeyService.Verify(c => c.GetKeysStartingWith("Paintings"), Times.Once);
        }

        [Fact]
        public async Task DeletePainting_ThrowsNotFoundException_WhenPaintingNotFound()
        {
            // Arrange
            var paintingId = Guid.NewGuid();

            var response = new DeletePaintingCommandResponse
            {
                Success = false,
                Message = $"{nameof(Painting)} not found"
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<DeletePaintingCommand>(c => c.Id == paintingId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(
                () => _controller.DeletePainting(paintingId));
        }

        #endregion

        #region UserFavorites

        [Fact]
        public async Task AddPaintingToFavorites_ReturnsOkResult_WhenValidCommand()
        {
            // Arrange
            var paintingId = Guid.NewGuid();
            var userId = "user123";

            // Setup user claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            var response = new AddPaintingToFavoriteCommandResponse
            {
                Success = true,
                IsFavorite = true,
                Message = "Painting added to favorites"
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<AddPaintingToFavoriteCommand>(
                        c => c.UserId == userId && c.PaintingId == paintingId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.AddPaintingToFavorites(paintingId);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;

            // Convert to serialized JSON to avoid dynamic binding issues
            var json = System.Text.Json.JsonSerializer.Serialize(okResult.Value);
            var resultObj = System.Text.Json.JsonSerializer
                .Deserialize<Dictionary<string, System.Text.Json.JsonElement>>(json);

            resultObj.Should().ContainKey("isFavorite");
            resultObj["isFavorite"].GetBoolean().Should().BeTrue();
        }

        [Fact]
        public async Task GetFavoritePaintings_ReturnsOkResult_WithUserFavorites()
        {
            // Arrange
            var userId = "user123";

            // Setup user claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            var response = new UserFavoritePaintingsResponse
            {
                Success = true,
                Count = 2,
                FavoritePaintings = new List<PaintingDto>
                {
                    new PaintingDto { Id = Guid.NewGuid(), Title = "Starry Night" },
                    new PaintingDto { Id = Guid.NewGuid(), Title = "Sunflowers" }
                }
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<GetUserFavoritePaintingsQuery>(q => q.UserId == userId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.GetFavoritePaintings();

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var returnValue = okResult.Value.Should().BeAssignableTo<UserFavoritePaintingsResponse>().Subject;
            returnValue.Count.Should().Be(2);
            returnValue.FavoritePaintings.Should().HaveCount(2);
        }

        #endregion
    }
}