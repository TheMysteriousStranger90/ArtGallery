namespace ArtGallery.ClientApp.Exceptions;


public class ApiException : Exception
{
    public int StatusCode { get; }
    public string Response { get; }
    public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; }

    public ApiException(string message, int statusCode, string response, IReadOnlyDictionary<string, IEnumerable<string>>? headers, Exception? innerException)
        : base(message, innerException)
    {
        StatusCode = statusCode;
        Response = response ?? string.Empty;
        Headers = headers ?? new Dictionary<string, IEnumerable<string>>();
    }
}