using System.Text.Json.Serialization;
using ArtGallery.Domain.Entities.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ArtGallery.Application.Features.Paintings.Commands;

public class UpdatePaintingCommand : IRequest<UpdatePaintingCommandResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int CreationYear { get; set; }
    public string Medium { get; set; }
    public string Dimensions { get; set; }
    public IFormFile Image { get; set; }
    public bool KeepExistingImage { get; set; } = true;
    public PaintType PaintType { get; set; }
    public Guid ArtistId { get; set; }
    public Guid? GenreId { get; set; }
    public Guid? MuseumId { get; set; }
    public List<Guid> TagIds { get; set; } = new List<Guid>();
}