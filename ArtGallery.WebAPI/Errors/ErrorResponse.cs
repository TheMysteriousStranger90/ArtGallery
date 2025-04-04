namespace ArtGallery.WebAPI.Errors;

public class ErrorResponse
{
    public IEnumerable<string> Errors { get; set; } = new List<string>();
    public string? StackTrace { get; set; }
}