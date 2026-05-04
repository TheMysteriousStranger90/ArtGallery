using System.Net;

namespace ArtGallery.Application.Exceptions;

public class UnauthorizedException : CustomException
{
    public UnauthorizedException(string message)
        : base(message, null, HttpStatusCode.Unauthorized)
    {
    }
}