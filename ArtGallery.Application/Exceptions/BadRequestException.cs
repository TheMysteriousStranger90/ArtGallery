using System.Net;

namespace ArtGallery.Application.Exceptions;

public class BadRequestException : CustomException
{
    public BadRequestException(string message)
        : base(message, null, HttpStatusCode.BadRequest)
    {
    }
        
    public BadRequestException(string message, List<string> errors)
        : base(message, errors, HttpStatusCode.BadRequest)
    {
    }
}