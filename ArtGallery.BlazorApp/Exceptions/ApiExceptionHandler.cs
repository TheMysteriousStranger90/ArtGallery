using ArtGallery.BlazorApp.Services;

namespace ArtGallery.BlazorApp.Exceptions;

public class ApiExceptionHandler
{
    public static async Task<T> HandleApiOperationAsync<T>(Func<Task<T>> apiCall, string genericErrorMessage = "An error occurred")
    {
        try
        {
            return await apiCall();
        }
        catch (ApiException ex)
        {
            switch (ex.StatusCode)
            {
                case 400:
                    throw new Exception($"Bad request: {ex.Response}");
                case 401:
                    throw new Exception("Your session has expired. Please log in again.");
                case 403:
                    throw new Exception("You don't have permission to perform this action.");
                case 404:
                    throw new Exception("The requested resource was not found.");
                case 429:
                    throw new Exception("Too many requests. Please try again later.");
                default:
                    throw new Exception($"{genericErrorMessage}: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"{genericErrorMessage}: {ex.Message}");
        }
    }
}