using ArtGallery.ClientApp.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtGallery.ClientApp.Services
{
    public class PaintingService : IPaintingService
    {
        private readonly IClient _client;
        private readonly ILogger<PaintingService> _logger;
        private const string DefaultApiVersion = "1.0";

        public PaintingService(IClient client, ILogger<PaintingService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Pagination_1OfOfPaintingDtoAndApplicationAnd_0AndCulture_neutralAndPublicKeyToken_null> GetPaintingsAsync(
            int pageIndex = 1, int pageSize = 9, string search = "", Guid? artistId = null, Guid? genreId = null,
            Guid? museumId = null, PaintType? paintType = null, int? fromYear = null, int? toYear = null,
            string sort = "title", string apiVersion = DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching paintings with params: pageIndex={PageIndex}, pageSize={PageSize}, search={Search}, sort={Sort}",
                    pageIndex, pageSize, search, sort);
                return await _client.PaintingsGET2Async(pageIndex, pageSize, search, artistId, genreId, museumId,
                                                       paintType, fromYear, toYear, sort, apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error fetching paintings. Status: {StatusCode}, Response: {Response}", ex.StatusCode, ex.Response);

                return new Pagination_1OfOfPaintingDtoAndApplicationAnd_0AndCulture_neutralAndPublicKeyToken_null
                {
                    Data = new List<PaintingDto>(),
                    Count = 0,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching paintings.");
                return new Pagination_1OfOfPaintingDtoAndApplicationAnd_0AndCulture_neutralAndPublicKeyToken_null
                {
                    Data = new List<PaintingDto>(),
                    Count = 0,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }
        }

        public async Task<PaintingDetailDto> GetPaintingAsync(Guid id, string apiVersion = DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching painting details for ID: {PaintingId}", id);
                return await _client.PaintingsGETAsync(id, apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error fetching painting details for ID {PaintingId}. Status: {StatusCode}, Response: {Response}", id, ex.StatusCode, ex.Response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching painting details for ID {PaintingId}.", id);
                return null;
            }
        }

        public async Task<PaintingDto> CreatePaintingAsync(
            string title, string description, int creationYear, string medium, string dimensions,
            FileParameter image, PaintType paintType, Guid artistId, Guid genreId, Guid museumId,
            IEnumerable<Guid> tagIds, string apiVersion = DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Creating painting: {Title}", title);
                
                return await _client.PaintingsPOSTAsync(apiVersion, title, description, creationYear, medium, dimensions,
                                                       image, paintType, artistId, genreId, museumId, tagIds);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error creating painting. Status: {StatusCode}, Response: {Response}", ex.StatusCode, ex.Response);

                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error creating painting.");
                throw;
            }
        }

        public async Task<PaintingDto> UpdatePaintingAsync(
            Guid paintingId, Guid id, string title, string description, int creationYear, string medium,
            string dimensions, FileParameter? image, bool keepExistingImage, PaintType paintType,
            Guid artistId, Guid genreId, Guid museumId, IEnumerable<Guid> tagIds, string apiVersion = DefaultApiVersion)
        {
            if (paintingId != id)
            {
                _logger.LogError("Mismatched IDs in UpdatePaintingAsync. Route ID: {PaintingId}, Body ID: {Id}", paintingId, id);
                throw new ArgumentException("The ID in the URL must match the ID in the request body content.");
            }

            try
            {
                _logger.LogInformation("Updating painting ID: {PaintingId}", paintingId);
                
                return await _client.PaintingsPUTAsync(paintingId, apiVersion, id, title, description, creationYear, medium,
                                                      dimensions, image, keepExistingImage, paintType, artistId,
                                                      genreId, museumId, tagIds);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error updating painting ID {PaintingId}. Status: {StatusCode}, Response: {Response}", paintingId, ex.StatusCode, ex.Response);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error updating painting ID {PaintingId}.", paintingId);
                throw;
            }
        }

        public async Task<bool> DeletePaintingAsync(Guid id, string apiVersion = DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Deleting painting ID: {PaintingId}", id);
                await _client.PaintingsDELETEAsync(id, apiVersion);
                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error deleting painting ID {PaintingId}. Status: {StatusCode}, Response: {Response}", id, ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error deleting painting ID {PaintingId}.", id);
                return false;
            }
        }

        public async Task<bool> AddPaintingToFavoritesAsync(Guid paintingId, string apiVersion = DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Adding painting ID {PaintingId} to favorites.", paintingId);

                await _client.PaintingsPOST2Async(paintingId, apiVersion);

                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error adding painting ID {PaintingId} to favorites. Status: {StatusCode}, Response: {Response}", paintingId, ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error adding painting ID {PaintingId} to favorites.", paintingId);
                return false;
            }
        }

        public async Task<UserFavoritePaintingsResponse> GetFavoritePaintingsAsync(string apiVersion = DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching favorite paintings for current user.");
                
                return await _client.PaintingsGETAsync(apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error fetching favorite paintings. Status: {StatusCode}, Response: {Response}", ex.StatusCode, ex.Response);
                return new UserFavoritePaintingsResponse { Success = false, Message = "API error occurred.", FavoritePaintings = new List<PaintingDto>() };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching favorite paintings.");
                return new UserFavoritePaintingsResponse { Success = false, Message = "An unexpected error occurred.", FavoritePaintings = new List<PaintingDto>() };
            }
        }
    }
}