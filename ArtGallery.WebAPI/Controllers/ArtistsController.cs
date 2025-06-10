using System.Net;
using System.Security.Claims;
using ArtGallery.Application.Features.Artists.Commands;
using ArtGallery.Application.Features.Artists.Queries;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Features.Paintings.Commands;
using ArtGallery.Application.Features.Paintings.Queries;
using ArtGallery.Application.Helpers;
using ArtGallery.Domain.Entities;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ApiVersion("1.0")]
public class ArtistsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ArtistsController> _logger;

    public ArtistsController(IMediator mediator, ILogger<ArtistsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Get a paginated list of artists with filtering and sorting options
    /// </summary>
    /// <param name="pageIndex">Page number (starts from 1)</param>
    /// <param name="pageSize">Number of items per page</param>
    /// <param name="search">Search term for artist name</param>
    /// <param name="nationality">Filter by nationality</param>
    /// <param name="sort">Sort field (e.g. lastName, firstName, birthDate)</param>
    /// <returns>Paginated list of artists</returns>
    [HttpGet]
    [ProducesResponseType(typeof(Pagination<ArtistDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<Pagination<ArtistDto>>> GetArtists(
        [FromQuery] int pageIndex = 1,
        [FromQuery] int pageSize = 10,
        [FromQuery] string search = "",
        [FromQuery] string nationality = "",
        [FromQuery] string sort = "lastName")
    {
        _logger.LogInformation("Getting artists list with pageIndex: {PageIndex}, pageSize: {PageSize}, " +
                              "search: {Search}, nationality: {Nationality}, sort: {Sort}",
                              pageIndex, pageSize, search, nationality, sort);

        var query = new GetArtistsListQuery
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Search = search,
            Nationality = nationality,
            Sort = sort
        };

        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Get a specific artist by ID
    /// </summary>
    /// <param name="id">Artist ID</param>
    /// <returns>Detailed information about the artist</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ArtistDetailDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ArtistDetailDto>> GetArtist(Guid id)
    {
        _logger.LogInformation("Getting artist details for ID: {ArtistId}", id);

        try
        {
            var query = new GetArtistDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex) when (ex.Message == nameof(Artist))
        {
            throw new NotFoundException($"Artist with id {id} not found");
        }
    }

    /// <summary>
    /// Get all unique artist nationalities
    /// </summary>
    /// <returns>List of nationalities</returns>
    [HttpGet("nationalities")]
    [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<string>>> GetNationalities()
    {
        _logger.LogInformation("Getting all artist nationalities");

        var query = new GetArtistNationalitiesQuery();
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Create a new artist
    /// </summary>
    /// <param name="command">Artist information</param>
    /// <returns>Created artist information</returns>
    [HttpPost]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(typeof(CreateArtistDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<CreateArtistDto>> CreateArtist([FromForm] CreateArtistCommand command)
    {
        _logger.LogInformation("Creating new artist: {FirstName} {LastName}", 
            command.FirstName, command.LastName);

        var response = await _mediator.Send(command);

        if (!response.Success)
        {
            if (response.ValidationErrors?.Count > 0)
            {
                // Return validation errors
                var problemDetails = new ValidationProblemDetails
                {
                    Title = "Validation errors occurred",
                    Status = (int)HttpStatusCode.BadRequest
                };

                foreach (var error in response.ValidationErrors)
                {
                    problemDetails.Errors.Add("Validation", new[] { error });
                }

                return BadRequest(problemDetails);
            }

            throw new BadRequestException(response.Message ?? "Error creating artist");
        }

        return CreatedAtAction(
            nameof(GetArtist), 
            new { id = response.Artist.Id }, 
            response.Artist
        );
    }

    /// <summary>
    /// Delete an artist
    /// </summary>
    /// <param name="id">Artist ID to delete</param>
    /// <returns>Success message</returns>
    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteArtist(Guid id)
    {
        _logger.LogInformation("Deleting artist with ID: {ArtistId}", id);

        var command = new DeleteArtistCommand { Id = id };
        var response = await _mediator.Send(command);

        if (!response.Success)
        {
            if (response.Message.Contains(nameof(Artist)))
            {
                throw new NotFoundException($"Artist with id {id} not found");
            }

            throw new BadRequestException(response.Message ?? "Error deleting artist");
        }

        return Ok(new { message = response.Message });
    }
    
    /// Add an artist to the current user's favorites
    /// </summary>
    /// <param name="artistId">ID of the artist to add to favorites</param>
    /// <returns>Status of the operation</returns>
    [HttpPost("artists/{artistId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AddArtistToFavorites(Guid artistId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _logger.LogInformation("Adding artist {ArtistId} to favorites for user {UserId}", artistId, userId);

        var command = new AddArtistToFavoriteCommand
        {
            UserId = userId,
            ArtistId = artistId
        };

        var result = await _mediator.Send(command);

        if (!result.Success)
        {
            return BadRequest(new { message = result.Message });
        }

        return Ok(new
        {
            isFavorite = result.IsFavorite,
            message = result.Message
        });
    }
    
        
    /// <summary>
    /// Get current user's favorite artists
    /// </summary>
    [HttpGet("artists")]
    [Authorize]
    [ProducesResponseType(typeof(UserFavoriteArtistsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserFavoriteArtistsResponse>> GetFavoriteArtists()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _logger.LogInformation("Getting favorite paintings for user {UserId}", userId);

        var query = new GetUserFavoriteArtistsQuery { UserId = userId };
        var result = await _mediator.Send(query);

        return Ok(result);
    }
}