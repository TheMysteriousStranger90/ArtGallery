using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Features.Exhibitions.Commands;
using ArtGallery.Application.Features.Exhibitions.Queries;
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
public class ExhibitionsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ExhibitionsController> _logger;

    public ExhibitionsController(IMediator mediator, ILogger<ExhibitionsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    /// <summary>
    /// Get all exhibitions with optional museum filter
    /// </summary>
    /// <param name="museumId">Optional filter by museum ID</param>
    /// <returns>List of exhibitions</returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<ExhibitionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ExhibitionDto>>> GetExhibitions([FromQuery] Guid? museumId = null)
    {
        _logger.LogInformation("Getting all exhibitions with museumId filter: {MuseumId}", museumId);
        
        var query = new GetExhibitionsListQuery { MuseumId = museumId };
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    /// <summary>
    /// Get current ongoing exhibitions
    /// </summary>
    /// <returns>List of current exhibitions</returns>
    [HttpGet("current")]
    [ProducesResponseType(typeof(List<ExhibitionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ExhibitionDto>>> GetCurrentExhibitions()
    {
        _logger.LogInformation("Getting current exhibitions");
        
        var query = new GetCurrentExhibitionsQuery();
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    /// <summary>
    /// Get past exhibitions that have already ended
    /// </summary>
    /// <returns>List of past exhibitions</returns>
    [HttpGet("past")]
    [ProducesResponseType(typeof(List<ExhibitionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ExhibitionDto>>> GetPastExhibitions()
    {
        _logger.LogInformation("Getting past exhibitions");
        
        var query = new GetPastExhibitionsQuery();
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    /// <summary>
    /// Get upcoming exhibitions that haven't started yet
    /// </summary>
    /// <returns>List of upcoming exhibitions</returns>
    [HttpGet("upcoming")]
    [ProducesResponseType(typeof(List<ExhibitionDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<ExhibitionDto>>> GetUpcomingExhibitions()
    {
        _logger.LogInformation("Getting upcoming exhibitions");
        
        var query = new GetUpcomingExhibitionsQuery();
        var result = await _mediator.Send(query);
        
        return Ok(result);
    }
    
    /// <summary>
    /// Get details of a specific exhibition
    /// </summary>
    /// <param name="id">Exhibition ID</param>
    /// <returns>Exhibition details with associated paintings</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ExhibitionDetailDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ExhibitionDetailDto>> GetExhibitionById(Guid id)
    {
        _logger.LogInformation("Getting exhibition details for ID: {ExhibitionId}", id);
        
        try
        {
            var query = new GetExhibitionDetailQuery { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex) when (ex.Message == nameof(Exhibition))
        {
            throw new NotFoundException($"Exhibition with ID {id} not found");
        }
    }
    
    /// <summary>
    /// Create a new exhibition
    /// </summary>
    /// <param name="command">Exhibition data</param>
    /// <returns>Created exhibition details</returns>
    [HttpPost]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(typeof(ExhibitionDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ExhibitionDto>> CreateExhibition([FromBody] CreateExhibitionCommand command)
    {
        _logger.LogInformation("Creating new exhibition: {Title}", command.Title);
        
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
            
            throw new BadRequestException(response.Message ?? "Failed to create exhibition");
        }
        
        return CreatedAtAction(nameof(GetExhibitionById), new { id = response.Exhibition.Id }, response.Exhibition);
    }
    
    /// <summary>
    /// Update an existing exhibition
    /// </summary>
    /// <param name="id">Exhibition ID</param>
    /// <param name="command">Updated exhibition data</param>
    /// <returns>Updated exhibition details</returns>
    [HttpPut("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(typeof(ExhibitionDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<ExhibitionDto>> UpdateExhibition(Guid id, [FromBody] UpdateExhibitionCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("The ID in the URL must match the ID in the request body");
        }
        
        _logger.LogInformation("Updating exhibition with ID: {ExhibitionId}", id);
        
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
            
            if (response.Message?.Contains(nameof(Exhibition)) == true)
            {
                throw new NotFoundException($"Exhibition with ID {id} not found");
            }
            
            throw new BadRequestException(response.Message ?? "Failed to update exhibition");
        }
        
        return Ok(response.Exhibition);
    }
    
    /// <summary>
    /// Delete an exhibition
    /// </summary>
    /// <param name="id">Exhibition ID to delete</param>
    /// <returns>Success message</returns>
    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteExhibition(Guid id)
    {
        _logger.LogInformation("Deleting exhibition with ID: {ExhibitionId}", id);
        
        var command = new DeleteExhibitionCommand { Id = id };
        var response = await _mediator.Send(command);
        
        if (!response.Success)
        {
            if (response.Message?.Contains(nameof(Exhibition)) == true)
            {
                throw new NotFoundException($"Exhibition with ID {id} not found");
            }
            
            throw new BadRequestException(response.Message ?? "Failed to delete exhibition");
        }
        
        return Ok(new { message = response.Message });
    }
    
    /// <summary>
    /// Add a painting to an exhibition
    /// </summary>
    /// <param name="exhibitionId">Exhibition ID</param>
    /// <param name="paintingId">Painting ID</param>
    /// <returns>Success message</returns>
    [HttpPost("{exhibitionId}/paintings/{paintingId}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> AddPaintingToExhibition(Guid exhibitionId, Guid paintingId)
    {
        _logger.LogInformation("Adding painting {PaintingId} to exhibition {ExhibitionId}", paintingId, exhibitionId);
        
        var command = new AddPaintingToExhibitionCommand
        {
            ExhibitionId = exhibitionId,
            PaintingId = paintingId
        };
        
        var response = await _mediator.Send(command);
        
        if (!response.Success)
        {
            if (response.Message?.Contains(nameof(Exhibition)) == true)
            {
                throw new NotFoundException($"Exhibition with ID {exhibitionId} not found");
            }
            
            if (response.Message?.Contains(nameof(Painting)) == true)
            {
                throw new NotFoundException($"Painting with ID {paintingId} not found");
            }
            
            throw new BadRequestException(response.Message ?? "Failed to add painting to exhibition");
        }
        
        return Ok(new { message = response.Message });
    }
    
    /// <summary>
    /// Remove a painting from an exhibition
    /// </summary>
    /// <param name="exhibitionId">Exhibition ID</param>
    /// <param name="paintingId">Painting ID</param>
    /// <returns>Success message</returns>
    [HttpDelete("{exhibitionId}/paintings/{paintingId}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> RemovePaintingFromExhibition(Guid exhibitionId, Guid paintingId)
    {
        _logger.LogInformation("Removing painting {PaintingId} from exhibition {ExhibitionId}", paintingId, exhibitionId);
        
        var command = new RemovePaintingFromExhibitionCommand
        {
            ExhibitionId = exhibitionId,
            PaintingId = paintingId
        };
        
        var response = await _mediator.Send(command);
        
        if (!response.Success)
        {
            if (response.Message?.Contains("Relation") == true)
            {
                throw new NotFoundException($"Painting {paintingId} is not part of exhibition {exhibitionId}");
            }
            
            throw new BadRequestException(response.Message ?? "Failed to remove painting from exhibition");
        }
        
        return Ok(new { message = response.Message });
    }
}