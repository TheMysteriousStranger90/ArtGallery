using ArtGallery.Application.DTOs;
using ArtGallery.Application.Features.Museums.Queries;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ApiVersion("1.0")]
public class MuseumsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<MuseumsController> _logger;

    public MuseumsController(IMediator mediator, ILogger<MuseumsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Get all museums
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<MuseumBriefDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MuseumBriefDto>>> GetMuseums()
    {
        _logger.LogInformation("Getting all museums");
        var result = await _mediator.Send(new GetMuseumsListQuery());
        return Ok(result);
    }

    /// <summary>
    /// Get museum by ID with its paintings
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(MuseumDetailDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<MuseumDetailDto>> GetMuseum(Guid id)
    {
        _logger.LogInformation("Getting museum with ID: {Id}", id);
        var result = await _mediator.Send(new GetMuseumDetailQuery { Id = id });
        return Ok(result);
    }
}
