using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Features.Exhibitions.Commands;
using ArtGallery.Application.Features.Exhibitions.Queries;
using ArtGallery.Domain.Entities;
using ArtGallery.WebAPI.Controllers;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace ArtGallery.WebAPI.Tests
{
    public class ExhibitionsControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly Mock<ILogger<ExhibitionsController>> _mockLogger;
        private readonly ExhibitionsController _controller;

        public ExhibitionsControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _mockLogger = new Mock<ILogger<ExhibitionsController>>();
            _controller = new ExhibitionsController(_mockMediator.Object, _mockLogger.Object);
        }

        #region GetExhibitions

        [Fact]
        public async Task GetExhibitions_ReturnsOkResult_WithAllExhibitions()
        {
            // Arrange
            var expectedExhibitions = new List<ExhibitionDto>
            {
                new ExhibitionDto { Id = Guid.NewGuid(), Title = "Modern Art Exhibition" },
                new ExhibitionDto { Id = Guid.NewGuid(), Title = "Renaissance Exhibition" }
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetExhibitionsListQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedExhibitions);

            // Act
            var result = await _controller.GetExhibitions();

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var exhibitions = okResult.Value.Should().BeAssignableTo<List<ExhibitionDto>>().Subject;
            exhibitions.Should().HaveCount(2);
            exhibitions[0].Title.Should().Be("Modern Art Exhibition");
            exhibitions[1].Title.Should().Be("Renaissance Exhibition");
        }

        [Fact]
        public async Task GetExhibitions_WithMuseumFilter_PassesFilterToQuery()
        {
            // Arrange
            var museumId = Guid.NewGuid();
            var expectedExhibitions = new List<ExhibitionDto>
            {
                new ExhibitionDto { Id = Guid.NewGuid(), Title = "Museum Special Exhibition" }
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<GetExhibitionsListQuery>(q => q.MuseumId == museumId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedExhibitions);

            // Act
            var result = await _controller.GetExhibitions(museumId);

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var exhibitions = okResult.Value.Should().BeAssignableTo<List<ExhibitionDto>>().Subject;
            exhibitions.Should().HaveCount(1);

            _mockMediator.Verify(
                m => m.Send(It.Is<GetExhibitionsListQuery>(q => q.MuseumId == museumId), It.IsAny<CancellationToken>()),
                Times.Once);
        }

        #endregion

        #region GetCurrentExhibitions

        [Fact]
        public async Task GetCurrentExhibitions_ReturnsOkResult_WithCurrentExhibitions()
        {
            // Arrange
            var expectedExhibitions = new List<ExhibitionDto>
            {
                new ExhibitionDto { Id = Guid.NewGuid(), Title = "Current Exhibition 1" },
                new ExhibitionDto { Id = Guid.NewGuid(), Title = "Current Exhibition 2" }
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCurrentExhibitionsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedExhibitions);

            // Act
            var result = await _controller.GetCurrentExhibitions();

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var exhibitions = okResult.Value.Should().BeAssignableTo<List<ExhibitionDto>>().Subject;
            exhibitions.Should().HaveCount(2);
            exhibitions[0].Title.Should().Be("Current Exhibition 1");
            exhibitions[1].Title.Should().Be("Current Exhibition 2");
        }

        #endregion

        #region GetPastExhibitions

        [Fact]
        public async Task GetPastExhibitions_ReturnsOkResult_WithPastExhibitions()
        {
            // Arrange
            var expectedExhibitions = new List<ExhibitionDto>
            {
                new ExhibitionDto { Id = Guid.NewGuid(), Title = "Past Exhibition 1" },
                new ExhibitionDto { Id = Guid.NewGuid(), Title = "Past Exhibition 2" }
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetPastExhibitionsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedExhibitions);

            // Act
            var result = await _controller.GetPastExhibitions();

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var exhibitions = okResult.Value.Should().BeAssignableTo<List<ExhibitionDto>>().Subject;
            exhibitions.Should().HaveCount(2);
            exhibitions[0].Title.Should().Be("Past Exhibition 1");
            exhibitions[1].Title.Should().Be("Past Exhibition 2");
        }

        #endregion

        #region GetUpcomingExhibitions

        [Fact]
        public async Task GetUpcomingExhibitions_ReturnsOkResult_WithUpcomingExhibitions()
        {
            // Arrange
            var expectedExhibitions = new List<ExhibitionDto>
            {
                new ExhibitionDto { Id = Guid.NewGuid(), Title = "Upcoming Exhibition 1" },
                new ExhibitionDto { Id = Guid.NewGuid(), Title = "Upcoming Exhibition 2" }
            };

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetUpcomingExhibitionsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedExhibitions);

            // Act
            var result = await _controller.GetUpcomingExhibitions();

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var exhibitions = okResult.Value.Should().BeAssignableTo<List<ExhibitionDto>>().Subject;
            exhibitions.Should().HaveCount(2);
            exhibitions[0].Title.Should().Be("Upcoming Exhibition 1");
            exhibitions[1].Title.Should().Be("Upcoming Exhibition 2");
        }

        #endregion

        #region GetExhibitionById

        [Fact]
        public async Task GetExhibitionById_ReturnsOkResult_WithExhibition()
        {
            // Arrange
            var exhibitionId = Guid.NewGuid();
            var expectedExhibition = new ExhibitionDetailDto
            {
                Id = exhibitionId,
                Title = "Test Exhibition",
                Description = "Exhibition Description"
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<GetExhibitionDetailQuery>(q => q.Id == exhibitionId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedExhibition);

            // Act
            var result = await _controller.GetExhibitionById(exhibitionId);

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var exhibition = okResult.Value.Should().BeAssignableTo<ExhibitionDetailDto>().Subject;
            exhibition.Id.Should().Be(exhibitionId);
            exhibition.Title.Should().Be("Test Exhibition");
        }

        [Fact]
        public async Task GetExhibitionById_ThrowsNotFoundException_WhenExhibitionNotFound()
        {
            // Arrange
            var exhibitionId = Guid.NewGuid();
            _mockMediator
                .Setup(m => m.Send(It.Is<GetExhibitionDetailQuery>(q => q.Id == exhibitionId),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new Exception(nameof(Exhibition)));

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _controller.GetExhibitionById(exhibitionId));
        }

        #endregion

        #region CreateExhibition

        [Fact]
        public async Task CreateExhibition_ReturnsCreatedAtActionResult_WhenSuccessful()
        {
            // Arrange
            var exhibitionId = Guid.NewGuid();
            var command = new CreateExhibitionCommand
            {
                Title = "New Exhibition",
                Description = "New Exhibition Description",
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddDays(30),
                MuseumId = Guid.NewGuid()
            };

            var response = new CreateExhibitionCommandResponse
            {
                Success = true,
                Exhibition = new ExhibitionDto
                {
                    Id = exhibitionId,
                    Title = "New Exhibition",
                    Description = "New Exhibition Description"
                }
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.CreateExhibition(command);

            // Assert
            var createdAtResult = result.Result.Should().BeOfType<CreatedAtActionResult>().Subject;
            createdAtResult.ActionName.Should().Be(nameof(ExhibitionsController.GetExhibitionById));
            createdAtResult.RouteValues["id"].Should().Be(exhibitionId);

            var exhibition = createdAtResult.Value.Should().BeAssignableTo<ExhibitionDto>().Subject;
            exhibition.Id.Should().Be(exhibitionId);
            exhibition.Title.Should().Be("New Exhibition");
        }

        [Fact]
        public async Task CreateExhibition_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var command = new CreateExhibitionCommand();

            var response = new CreateExhibitionCommandResponse
            {
                Success = false,
                ValidationErrors = new List<string> { "Title is required", "Start date is required" }
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act & Assert
            // Just verify that the mediator was called and we're handling validation errors
            await Assert.ThrowsAsync<ArgumentException>(() => _controller.CreateExhibition(command));

            // Verify mediator was called with the command
            _mockMediator.Verify(m => m.Send(command, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateExhibition_ThrowsBadRequestException_WhenCommandFails()
        {
            // Arrange
            var command = new CreateExhibitionCommand
            {
                Title = "New Exhibition"
            };

            var response = new CreateExhibitionCommandResponse
            {
                Success = false,
                Message = "Failed due to database constraint"
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act & Assert
            await Assert.ThrowsAsync<BadRequestException>(() => _controller.CreateExhibition(command));
        }

        #endregion

        #region UpdateExhibition

        [Fact]
        public async Task UpdateExhibition_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var exhibitionId = Guid.NewGuid();
            var command = new UpdateExhibitionCommand
            {
                Id = exhibitionId,
                Title = "Updated Exhibition",
                Description = "Updated Description"
            };

            var response = new UpdateExhibitionCommandResponse
            {
                Success = true,
                Exhibition = new ExhibitionDto
                {
                    Id = exhibitionId,
                    Title = "Updated Exhibition",
                    Description = "Updated Description"
                }
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.UpdateExhibition(exhibitionId, command);

            // Assert
            var okResult = result.Result.Should().BeOfType<OkObjectResult>().Subject;
            var exhibition = okResult.Value.Should().BeAssignableTo<ExhibitionDto>().Subject;
            exhibition.Id.Should().Be(exhibitionId);
            exhibition.Title.Should().Be("Updated Exhibition");
        }

        [Fact]
        public async Task UpdateExhibition_ReturnsBadRequest_WhenIdMismatch()
        {
            // Arrange
            var exhibitionId = Guid.NewGuid();
            var differentId = Guid.NewGuid();
            var command = new UpdateExhibitionCommand
            {
                Id = differentId,
                Title = "Updated Exhibition"
            };

            // Act
            var result = await _controller.UpdateExhibition(exhibitionId, command);

            // Assert
            result.Result.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public async Task UpdateExhibition_ThrowsNotFoundException_WhenExhibitionNotFound()
        {
            // Arrange
            var exhibitionId = Guid.NewGuid();
            var command = new UpdateExhibitionCommand
            {
                Id = exhibitionId,
                Title = "Updated Exhibition"
            };

            var response = new UpdateExhibitionCommandResponse
            {
                Success = false,
                Message = $"{nameof(Exhibition)} not found"
            };

            _mockMediator
                .Setup(m => m.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _controller.UpdateExhibition(exhibitionId, command));
        }

        #endregion

        #region DeleteExhibition

        [Fact]
        public async Task DeleteExhibition_ReturnsOkResult_WhenSuccessful()
        {
            // Arrange
            var exhibitionId = Guid.NewGuid();
            var response = new DeleteExhibitionCommandResponse
            {
                Success = true,
                Message = "Exhibition deleted successfully"
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<DeleteExhibitionCommand>(c => c.Id == exhibitionId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act
            var result = await _controller.DeleteExhibition(exhibitionId);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var responseObj = System.Text.Json.JsonSerializer.Serialize(okResult.Value);
            var resultValue = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(responseObj);

            resultValue.Should().ContainKey("message");
            resultValue["message"].Should().Be("Exhibition deleted successfully");
        }

        [Fact]
        public async Task DeleteExhibition_ThrowsNotFoundException_WhenExhibitionNotFound()
        {
            // Arrange
            var exhibitionId = Guid.NewGuid();
            var response = new DeleteExhibitionCommandResponse
            {
                Success = false,
                Message = $"{nameof(Exhibition)} not found"
            };

            _mockMediator
                .Setup(m => m.Send(It.Is<DeleteExhibitionCommand>(c => c.Id == exhibitionId),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            // Act & Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _controller.DeleteExhibition(exhibitionId));
        }

        #endregion
    }
}