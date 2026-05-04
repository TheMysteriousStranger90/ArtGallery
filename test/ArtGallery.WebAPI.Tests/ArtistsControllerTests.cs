using System.Security.Claims;
using System.Text.Json;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Features.Artists.Commands;
using ArtGallery.Application.Features.Artists.Queries;
using ArtGallery.Application.Helpers;
using ArtGallery.Domain.Entities;
using ArtGallery.WebAPI.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace ArtGallery.WebAPI.Tests
{
    public class ArtistsControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly Mock<ILogger<ArtistsController>> _mockLogger;
        private readonly ArtistsController _controller;

        public ArtistsControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _mockLogger = new Mock<ILogger<ArtistsController>>();
            _controller = new ArtistsController(_mockMediator.Object, _mockLogger.Object);
        }

        #region GetArtists

        [Fact]
        public async Task GetArtists_ReturnsOkResult_WithPaginatedList()
        {
            // Arrange
            var artists = new List<ArtistDto>
            {
                new ArtistDto { Id = Guid.NewGuid(), FirstName = "Vincent", LastName = "Van Gogh" },
                new ArtistDto { Id = Guid.NewGuid(), FirstName = "Claude", LastName = "Monet" }
            };

            // Use constructor rather than object initializer
            var expectedResponse = new Pagination<ArtistDto>(
                pageIndex: 1,
                pageSize: 10,
                count: 2,
                data: artists
            );

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetArtistsListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetArtists(1, 10, "", "", "lastName");

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var artistsResult = okResult.Value.Should().BeAssignableTo<Pagination<ArtistDto>>().Subject;
            artistsResult.Data.Should().HaveCount(2);
            artistsResult.PageIndex.Should().Be(1);
            artistsResult.PageSize.Should().Be(10);
            artistsResult.Count.Should().Be(2);

            _mockMediator.Verify(m => m.Send(
                    It.Is<GetArtistsListQuery>(q =>
                        q.PageIndex == 1 &&
                        q.PageSize == 10 &&
                        q.Search == "" &&
                        q.Nationality == "" &&
                        q.Sort == "lastName"),
                    It.IsAny<CancellationToken>()),
                Times.Once);
        }

        #endregion

        #region GetArtist

        [Fact]
        public async Task GetArtist_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var biographyId = Guid.NewGuid();

            var expectedArtist = new ArtistDetailDto
            {
                Id = artistId,
                FirstName = "Vincent",
                LastName = "Van Gogh",
                Nationality = "Dutch",
                // Create proper BiographyDto object
                Biography = new BiographyDto
                {
                    Id = biographyId,
                    Content = "Test biography content",
                    ShortDescription = "Dutch post-impressionist painter",
                    References = "Various sources"
                }
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<GetArtistDetailQuery>(q => q.Id == artistId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedArtist);

            // Act
            var result = await _controller.GetArtist(artistId);

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var artist = okResult.Value.Should().BeAssignableTo<ArtistDetailDto>().Subject;
            artist.Id.Should().Be(artistId);
            artist.FirstName.Should().Be("Vincent");
            artist.LastName.Should().Be("Van Gogh");
            artist.Biography.Should().NotBeNull();
            artist.Biography.Content.Should().Be("Test biography content");
        }

        [Fact]
        public async Task GetArtist_WithInvalidId_ThrowsNotFoundException()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            _mockMediator
                .Setup(m => m.Send(It.Is<GetArtistDetailQuery>(q => q.Id == artistId), It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception(nameof(Artist)));

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _controller.GetArtist(artistId));
        }

        #endregion

        #region GetNationalities

        [Fact]
        public async Task GetNationalities_ReturnsListOfNationalities()
        {
            // Arrange
            var expectedNationalities = new List<string> { "Dutch", "French", "Italian" };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetArtistNationalitiesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedNationalities);

            // Act
            var result = await _controller.GetNationalities();

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var nationalities = okResult.Value.Should().BeAssignableTo<List<string>>().Subject;
            nationalities.Should().HaveCount(3);
            nationalities.Should().Contain("Dutch");
            nationalities.Should().Contain("French");
            nationalities.Should().Contain("Italian");
        }

        #endregion

        #region CreateArtist

        [Fact]
        public async Task CreateArtist_WithValidCommand_ReturnsCreatedResult()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var command = new CreateArtistCommand
            {
                FirstName = "Vincent",
                LastName = "Van Gogh",
                // Instead of setting Biography directly, we'll handle this in the command validation
                Nationality = "Dutch"
            };

            var response = new CreateArtistCommandResponse
            {
                Success = true,
                Artist = new CreateArtistDto
                {
                    Id = artistId,
                    FirstName = "Vincent",
                    LastName = "Van Gogh"
                }
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.CreateArtist(command);

            // Assert
            var createdAtResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
            createdAtResult.ActionName.Should().Be(nameof(ArtistsController.GetArtist));
            createdAtResult.RouteValues["id"].Should().Be(artistId);

            var returnValue = createdAtResult.Value.Should().BeAssignableTo<CreateArtistDto>().Subject;
            returnValue.Id.Should().Be(artistId);
            returnValue.FirstName.Should().Be("Vincent");
            returnValue.LastName.Should().Be("Van Gogh");
        }

        [Fact]
        public async Task CreateArtist_WithInvalidCommand_ReturnsBadRequest()
        {
            // Arrange
            var command = new CreateArtistCommand
            {
                FirstName = "Vincent",
                LastName = "Van Gogh"
            };

            var response = new CreateArtistCommandResponse
            {
                Success = false,
                ValidationErrors = new List<string> { "Biography is required" }
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.CreateArtist(command);

            // Assert
            var badRequestResult = result.Result.Should().BeOfType<BadRequestObjectResult>().Subject;
            var validationProblems = badRequestResult.Value.Should().BeAssignableTo<ValidationProblemDetails>().Subject;
            validationProblems.Errors.Should().ContainKey("Validation");
            validationProblems.Errors["Validation"].Should().Contain("Biography is required");
        }

        [Fact]
        public async Task CreateArtist_WithErrorResponse_ThrowsBadRequestException()
        {
            // Arrange
            var command = new CreateArtistCommand
            {
                FirstName = "Vincent",
                LastName = "Van Gogh"
            };

            var response = new CreateArtistCommandResponse
            {
                Success = false,
                Message = "Database error"
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _controller.CreateArtist(command));
        }

        #endregion

        #region DeleteArtist

        [Fact]
        public async Task DeleteArtist_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var response = new DeleteArtistCommandResponse
            {
                Success = true,
                Message = "Artist deleted successfully"
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<DeleteArtistCommand>(c => c.Id == artistId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.DeleteArtist(artistId);

            // Assert
            result.Should().BeOfType<OkObjectResult>();

            var okResult = (OkObjectResult)result;
            var propertyInfo = okResult.Value.GetType().GetProperties()
                .FirstOrDefault(p => p.Name.ToLowerInvariant().Contains("message"));

            propertyInfo.Should().NotBeNull("Response should have a message property");
            var propertyValue = propertyInfo.GetValue(okResult.Value)?.ToString();
            propertyValue.Should().Be("Artist deleted successfully");
        }

        [Fact]
        public async Task DeleteArtist_WithInvalidId_ThrowsNotFoundException()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var response = new DeleteArtistCommandResponse
            {
                Success = false,
                Message = $"{nameof(Artist)} not found"
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<DeleteArtistCommand>(c => c.Id == artistId), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _controller.DeleteArtist(artistId));
        }

        #endregion

        #region AddArtistToFavorites

        [Fact]
        public async Task AddArtistToFavorites_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var userId = "user-123";

            // Setup ClaimsPrincipal for the controller
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, userId)
            };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);

            // Setup controller context
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            var response = new AddArtistToFavoriteCommandResponse
            {
                Success = true,
                IsFavorite = true,
                Message = "Artist added to favorites successfully"
            };

            _mockMediator
                .Setup(m => m.Send(
                    It.Is<AddArtistToFavoriteCommand>(c =>
                        c.UserId == userId &&
                        c.ArtistId == artistId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.AddArtistToFavorites(artistId);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;

            // Convert to serialized JSON to avoid dynamic binding issues
            var json = System.Text.Json.JsonSerializer.Serialize(okResult.Value);
            var resultObj = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            resultObj.Should().ContainKey("isFavorite");
            resultObj["isFavorite"].GetBoolean().Should().BeTrue();

            resultObj.Should().ContainKey("message");
            resultObj["message"].GetString().Should().Be("Artist added to favorites successfully");
        }

        [Fact]
        public async Task AddArtistToFavorites_WithError_ReturnsBadRequest()
        {
            // Arrange
            var artistId = Guid.NewGuid();
            var userId = "user-123";

            // Setup ClaimsPrincipal
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            var response = new AddArtistToFavoriteCommandResponse
            {
                Success = false,
                Message = "Artist not found"
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<AddArtistToFavoriteCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.AddArtistToFavorites(artistId);

            // Assert
            var badRequestResult = result.Should().BeOfType<BadRequestObjectResult>().Subject;

            var json = System.Text.Json.JsonSerializer.Serialize(badRequestResult.Value);
            var resultObj = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            resultObj.Should().ContainKey("message");
            resultObj["message"].GetString().Should().Be("Artist not found");
        }

        #endregion

        #region GetFavoriteArtists

        [Fact]
        public async Task GetFavoriteArtists_ReturnsOkResultWithArtists()
        {
            // Arrange
            var userId = "user-123";

            // Setup ClaimsPrincipal
            var claims = new List<Claim> { new Claim(ClaimTypes.NameIdentifier, userId) };
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            var expectedResponse = new UserFavoriteArtistsResponse
            {
                Success = true,
                Count = 2,
                FavoriteArtists = new List<ArtistDto>
                {
                    new ArtistDto { Id = Guid.NewGuid(), FirstName = "Vincent", LastName = "Van Gogh" },
                    new ArtistDto { Id = Guid.NewGuid(), FirstName = "Claude", LastName = "Monet" }
                }
            };

            _mockMediator
                .Setup(m => m.Send(
                    It.Is<GetUserFavoriteArtistsQuery>(q => q.UserId == userId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller.GetFavoriteArtists();

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var response = okResult.Value.Should().BeAssignableTo<UserFavoriteArtistsResponse>().Subject;
            response.FavoriteArtists.Should().HaveCount(2);
            response.Count.Should().Be(2);
        }

        #endregion
    }
}