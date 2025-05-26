using ArtGallery.BlazorApp.Services;
using Microsoft.Extensions.Logging;

namespace ArtGallery.BlazorApp.Exceptions;

public static class ApiExceptionHandler
{
    public static async Task<T> HandleApiOperationAsync<T>(
        Func<Task<T>> operation,
        string errorMessage,
        ILogger? logger = null)
    {
        try
        {
            logger?.LogDebug("Executing API operation");
            var result = await operation();
            logger?.LogDebug("API operation completed successfully. Result is null: {IsNull}, Result type: {Type}",
                result == null, result?.GetType().Name ?? "null");
            return result;
        }
        catch (ApiException apiEx)
        {
            logger?.LogError(apiEx, "API Exception occurred: Status={StatusCode}, Response={Response}",
                apiEx.StatusCode, apiEx.Response);
            throw new ApplicationException($"{errorMessage}: Status {apiEx.StatusCode} ");
        }
        catch (HttpRequestException httpEx)
        {
            logger?.LogError(httpEx, "HTTP Request Exception occurred");
            throw new ApplicationException($"{errorMessage}: Network error - {httpEx.Message}");
        }
        catch (TaskCanceledException tcEx)
        {
            logger?.LogError(tcEx, "Request timeout occurred");
            throw new ApplicationException($"{errorMessage}: Request timeout");
        }
        catch (Exception ex)
        {
            logger?.LogError(ex, "General exception occurred during API operation. Exception type: {ExceptionType}",
                ex.GetType().Name);
            throw new ApplicationException($"{errorMessage}: {ex.Message}");
        }
    }
}