using ArtGallery.Application.DTOs;
using ArtGallery.Application.Exceptions;
using ArtGallery.Application.Features.Tags.Commands;
using ArtGallery.Application.Features.Tags.Queries;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ApiVersion("1.0")]
public class TagsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<TagsController> _logger;

    public TagsController(IMediator mediator, ILogger<TagsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>Get all tags</summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<TagDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TagDto>>> GetTags()
    {
        _logger.LogInformation("Getting all tags");
        var result = await _mediator.Send(new GetTagsListQuery());
        return Ok(result.Tags);
    }

    /// <summary>Get a specific tag by ID</summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TagDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TagDto>> GetTag(Guid id)
    {
        _logger.LogInformation("Getting tag with ID: {TagId}", id);
        var result = await _mediator.Send(new GetTagDetailQuery { Id = id });

        if (!result.Success)
        {
            throw new NotFoundException(result.Message);
        }

        return Ok(result.Tag);
    }

    /// <summary>Create a new tag (Admin only)</summary>
    [HttpPost]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(typeof(TagDto), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<TagDto>> CreateTag([FromBody] CreateTagCommand command)
    {
        _logger.LogInformation("Creating tag: {Name}", command.Name);
        var result = await _mediator.Send(command);

        if (!result.Success)
        {
            if (result.ValidationErrors?.Count > 0)
            {
                var problemDetails = new ValidationProblemDetails();
                foreach (var error in result.ValidationErrors)
                {
                    problemDetails.Errors.Add("Validation", new[] { error });
                }
                return BadRequest(problemDetails);
            }

            throw new BadRequestException(result.Message ?? "Error creating tag");
        }

        return CreatedAtAction(nameof(GetTag), new { id = result.Tag!.Id }, result.Tag);
    }

    /// <summary>Update an existing tag (Admin only)</summary>
    [HttpPut("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(typeof(TagDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<ActionResult<TagDto>> UpdateTag(Guid id, [FromBody] UpdateTagCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest("The ID in the URL must match the ID in the request body");
        }

        _logger.LogInformation("Updating tag with ID: {TagId}", id);
        var result = await _mediator.Send(command);

        if (!result.Success)
        {
            if (result.ValidationErrors?.Count > 0)
            {
                var problemDetails = new ValidationProblemDetails();
                foreach (var error in result.ValidationErrors)
                {
                    problemDetails.Errors.Add("Validation", new[] { error });
                }
                return BadRequest(problemDetails);
            }

            if (result.Message?.Contains("not found") == true)
            {
                throw new NotFoundException(result.Message);
            }

            throw new BadRequestException(result.Message ?? "Error updating tag");
        }

        return Ok(result.Tag);
    }

    /// <summary>Delete a tag (Admin only)</summary>
    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireAdminRole")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public async Task<IActionResult> DeleteTag(Guid id)
    {
        _logger.LogInformation("Deleting tag with ID: {TagId}", id);
        var result = await _mediator.Send(new DeleteTagCommand { Id = id });

        if (!result.Success)
        {
            if (result.Message?.Contains("not found") == true)
            {
                throw new NotFoundException(result.Message);
            }

            throw new BadRequestException(result.Message ?? "Error deleting tag");
        }

        return Ok(new { message = result.Message });
    }
}