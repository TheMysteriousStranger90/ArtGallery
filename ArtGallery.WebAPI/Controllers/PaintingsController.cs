using System.Security.Claims;
using ArtGallery.Application.Contracts;
using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Features.Paintings.Commands;
using ArtGallery.Application.Features.Paintings.Queries;
using ArtGallery.Application.Helpers;
using ArtGallery.Domain.Entities;
using ArtGallery.Domain.Entities.Enums;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ArtGallery.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ApiVersion("1.0")]
public class PaintingsController : ControllerBase
{
    private const string PaintingsCacheKey = "Paintings";
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(1, 1);
    private readonly IMemoryCache _memoryCache;
    private readonly ICacheKeyService _cacheKeyService;

    private readonly IMediator _mediator;
    private readonly ILogger<PaintingsController> _logger;

    public PaintingsController(
        IMediator mediator,
        ILogger<PaintingsController> logger,
        IMemoryCache memoryCache,
        ICacheKeyService cacheKeyService)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        _cacheKeyService = cacheKeyService ?? throw new ArgumentNullException(nameof(cacheKeyService));
    }

    /// <summary>
    /// Get a paginated list of paintings with filtering and sorting options
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(Pagination<PaintingDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<Pagination<PaintingDto>>> GetPaintings(
        [FromQuery] int pageIndex = 1,
        [FromQuery] int pageSize = 9,
        [FromQuery] string search = "",
        [FromQuery] Guid? artistId = null,
        [FromQuery] Guid? genreId = null,
        [FromQuery] Guid? museumId = null,
        [FromQuery] PaintType? paintType = null,
        [FromQuery] int? fromYear = null,
        [FromQuery] int? toYear = null,
        [FromQuery] string sort = "title")
    {
        _logger.LogInformation(
            "Getting paintings with filters: pageIndex={PageIndex}, pageSize={PageSize}, search={Search}, " +
            "artistId={ArtistId}, genreId={GenreId}, museumId={MuseumId}, paintType={PaintType}, " +
            "fromYear={FromYear}, toYear={ToYear}, sort={Sort}",
            pageIndex, pageSize, search, artistId, genreId, museumId, paintType, fromYear, toYear, sort);

        // Create a cache key based on all query parameters
        string cacheKey =
            $"{PaintingsCacheKey}_{pageIndex}_{pageSize}_{search}_{artistId}_{genreId}_{museumId}_{paintType}_{fromYear}_{toYear}_{sort}";

        // Try to get from cache first
        if (!_memoryCache.TryGetValue(cacheKey, out Pagination<PaintingDto> paintingResult))
        {
            try
            {
                // Use semaphore to prevent cache stampede
                await semaphore.WaitAsync();

                // Double-check after acquiring the lock
                if (!_memoryCache.TryGetValue(cacheKey, out paintingResult))
                {
                    _logger.LogInformation("Paintings not found in cache. Fetching from database.");

                    var query = new GetPaintingsListQuery
                    {
                        PageIndex = pageIndex,
                        PageSize = pageSize,
                        Search = search,
                        ArtistId = artistId,
                        GenreId = genreId,
                        MuseumId = museumId,
                        PaintType = paintType,
                        FromYear = fromYear,
                        ToYear = toYear,
                        Sort = sort
                    };

                    paintingResult = await _mediator.Send(query);

                    // Set up cache options
                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
                        SlidingExpiration = TimeSpan.FromMinutes(2),
                        Priority = CacheItemPriority.Normal,
                        Size = 1024
                    };

                    // Add to cache and register cache key
                    _memoryCache.Set(cacheKey, paintingResult, cacheEntryOptions);
                    _cacheKeyService.AddKey(cacheKey);
                }
                else
                {
                    _logger.LogInformation("Paintings found in cache after acquiring lock.");
                }
            }
            finally
            {
                semaphore.Release();
            }
        }
        else
        {
            _logger.LogInformation("Paintings found in cache.");
        }

        return Ok(paintingResult);
    }

    /// <summary>
    /// Get a specific painting by ID
    /// </summary>
    /// <param name="id">Painting ID</param>
    /// <returns>Detailed information about the painting</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(PaintingDetailDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PaintingDetailDto>> GetPainting(Guid id)
    {
        _logger.LogInformation("Getting painting details for ID: {PaintingId}", id);

        // Create a cache key for individual painting
        string cacheKey = $"{PaintingsCacheKey}_Detail_{id}";

        // Try to get from cache first
        if (!_memoryCache.TryGetValue(cacheKey, out PaintingDetailDto paintingDetail))
        {
            try
            {
                await semaphore.WaitAsync();

                if (!_memoryCache.TryGetValue(cacheKey, out paintingDetail))
                {
                    _logger.LogInformation("Painting details not found in cache. Fetching from database.");

                    try
                    {
                        var query = new GetPaintingDetailQuery { Id = id };
                        paintingDetail = await _mediator.Send(query);

                        var cacheEntryOptions = new MemoryCacheEntryOptions
                        {
                            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10),
                            SlidingExpiration = TimeSpan.FromMinutes(5),
                            Priority = CacheItemPriority.Normal
                        };

                        _memoryCache.Set(cacheKey, paintingDetail, cacheEntryOptions);
                        _cacheKeyService.AddKey(cacheKey);
                    }
                    catch (Exception ex) when (ex.Message == nameof(Painting))
                    {
                        throw new NotFoundException($"Painting with ID {id} not found");
                    }
                }
            }
            finally
            {
                semaphore.Release();
            }
        }
        else
        {
            _logger.LogInformation("Painting details found in cache.");
        }

        return Ok(paintingDetail);
    }

    /// <summary>
    /// Create a new painting
    /// </summary>
    /// <param name="command">Painting information</param>
    /// <returns>Created painting information</returns>
    [HttpPost]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(typeof(PaintingDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<PaintingDto>> CreatePainting([FromForm] CreatePaintingCommand command)
    {
        _logger.LogInformation("Creating new painting: {Title} by artist ID {ArtistId}",
            command.Title, command.ArtistId);

        var response = await _mediator.Send(command);

        if (!response.Success)
        {
            if (response.ValidationErrors?.Count > 0)
            {
                var problemDetails = new ValidationProblemDetails();
                foreach (var error in response.ValidationErrors)
                {
                    problemDetails.Errors.Add("Validation", new[] { error });
                }

                return BadRequest(problemDetails);
            }

            throw new BadRequestException(response.Message ?? "Error creating painting");
        }

        // Invalidate cache after creating a painting
        InvalidatePaintingsCache();

        return CreatedAtAction(
            nameof(GetPainting),
            new { id = response.Painting.Id },
            response.Painting
        );
    }

    /// <summary>
    /// Update an existing painting
    /// </summary>
    /// <param name="id">Painting ID</param>
    /// <param name="command">Updated painting information</param>
    /// <returns>Updated painting information</returns>
    [HttpPut("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(typeof(PaintingDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<PaintingDto>> UpdatePainting(Guid id, [FromForm] UpdatePaintingCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("The ID in the URL must match the ID in the request body");
        }

        command.Id = id;

        _logger.LogInformation("Updating painting with ID: {PaintingId}", id);

        var response = await _mediator.Send(command);

        if (!response.Success)
        {
            if (response.ValidationErrors?.Count > 0)
            {
                var problemDetails = new ValidationProblemDetails();
                foreach (var error in response.ValidationErrors)
                {
                    problemDetails.Errors.Add("Validation", new[] { error });
                }

                return BadRequest(problemDetails);
            }

            if (response.Message?.Contains(nameof(Painting)) == true)
            {
                throw new NotFoundException($"Painting with ID {id} not found");
            }

            throw new BadRequestException(response.Message ?? "Error updating painting");
        }

        // Invalidate cache after updating
        InvalidatePaintingsCache();

        // Also remove specific painting detail cache
        var detailCacheKey = $"{PaintingsCacheKey}_Detail_{id}";
        _memoryCache.Remove(detailCacheKey);
        _cacheKeyService.RemoveKey(detailCacheKey);

        return Ok(response.Painting);
    }

    /// <summary>
    /// Delete a painting
    /// </summary>
    /// <param name="id">Painting ID to delete</param>
    /// <returns>Success message</returns>
    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeletePainting(Guid id)
    {
        _logger.LogInformation("Deleting painting with ID: {PaintingId}", id);

        var command = new DeletePaintingCommand { Id = id };
        var response = await _mediator.Send(command);

        if (!response.Success)
        {
            if (response.Message?.Contains(nameof(Painting)) == true)
            {
                throw new NotFoundException($"Painting with ID {id} not found");
            }

            throw new BadRequestException(response.Message ?? "Error deleting painting");
        }

        // Invalidate cache after deletion
        InvalidatePaintingsCache();

        // Also remove specific painting detail cache
        var detailCacheKey = $"{PaintingsCacheKey}_Detail_{id}";
        _memoryCache.Remove(detailCacheKey);
        _cacheKeyService.RemoveKey(detailCacheKey);

        return Ok(new { message = response.Message });
    }

    /// Add a painting to the current user's favorites
    /// </summary>
    /// <param name="paintingId">ID of the painting to add to favorites</param>
    /// <returns>Status of the operation</returns>
    [HttpPost("paintings/{paintingId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> AddPaintingToFavorites(Guid paintingId)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _logger.LogInformation("Adding painting {PaintingId} to favorites for user {UserId}", paintingId, userId);

        var command = new AddPaintingToFavoriteCommand
        {
            UserId = userId,
            PaintingId = paintingId
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
    /// Get current user's favorite paintings
    /// </summary>
    [HttpGet("paintings")]
    [Authorize]
    [ProducesResponseType(typeof(UserFavoritePaintingsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserFavoritePaintingsResponse>> GetFavoritePaintings()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        _logger.LogInformation("Getting favorite paintings for user {UserId}", userId);

        var query = new GetUserFavoritePaintingsQuery { UserId = userId };
        var result = await _mediator.Send(query);

        return Ok(result);
    }

    /// <summary>
    /// Invalidates all paintings-related cache entries
    /// </summary>
    private void InvalidatePaintingsCache()
    {
        var keysToRemove = _cacheKeyService.GetKeysStartingWith(PaintingsCacheKey);

        foreach (var key in keysToRemove)
        {
            _memoryCache.Remove(key);
            _cacheKeyService.RemoveKey(key);
        }

        _logger.LogInformation("Invalidated {Count} painting cache entries", keysToRemove.Count());
    }
}