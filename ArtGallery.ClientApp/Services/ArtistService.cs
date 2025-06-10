using ArtGallery.ClientApp.Services.Interfaces;
using ArtGallery.ClientApp.Constants;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArtGallery.ClientApp.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IClient _client;
        private readonly ILogger<ArtistService> _logger;

        public ArtistService(IClient client, ILogger<ArtistService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Pagination_1OfOfArtistDtoAndApplicationAnd_0AndCulture_neutralAndPublicKeyToken_null> GetArtistsAsync(
            int pageIndex = 1, int pageSize = 10, string search = "", string nationality = "", string sort = "lastName",
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation(
                    "Fetching artists with params: pageIndex={PageIndex}, pageSize={PageSize}, search={Search}, nationality={Nationality}, sort={Sort}",
                    pageIndex, pageSize, search, nationality, sort);
                
                return await _client.ArtistsGET2Async(pageIndex, pageSize, search, nationality, sort, apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error fetching artists. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);

                return new Pagination_1OfOfArtistDtoAndApplicationAnd_0AndCulture_neutralAndPublicKeyToken_null
                {
                    Data = new List<ArtistDto>(),
                    Count = 0,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching artists.");
                return new Pagination_1OfOfArtistDtoAndApplicationAnd_0AndCulture_neutralAndPublicKeyToken_null
                {
                    Data = new List<ArtistDto>(),
                    Count = 0,
                    PageIndex = pageIndex,
                    PageSize = pageSize
                };
            }
        }

        public async Task<ArtistDetailDto> GetArtistAsync(Guid id, string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching artist details for ID: {ArtistId}", id);
                return await _client.ArtistsGETAsync(id, apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error fetching artist details for ID {ArtistId}. Status: {StatusCode}, Response: {Response}",
                    id, ex.StatusCode, ex.Response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching artist details for ID {ArtistId}.", id);
                return null;
            }
        }

        public async Task<ICollection<string>> GetNationalitiesAsync(string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching all artist nationalities");
                return await _client.NationalitiesAsync(apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error fetching nationalities. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);
                return new List<string>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching nationalities.");
                return new List<string>();
            }
        }

        public async Task<CreateArtistDto> CreateArtistAsync(
            string firstName, string lastName, DateTimeOffset? birthDate, DateTimeOffset? deathDate, string nationality,
            FileParameter image, string biographyContent, string biographyShortDescription, string biographyReferences,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Creating artist: {FirstName} {LastName}", firstName, lastName);

                return await _client.ArtistsPOSTAsync(apiVersion, firstName, lastName, birthDate, deathDate, nationality,
                    image, biographyContent, biographyShortDescription, biographyReferences);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error creating artist. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);

                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error creating artist.");
                throw;
            }
        }
        
        public async Task<ArtistDto> UpdateArtistAsync(
            Guid id,
            string firstName, 
            string lastName, 
            DateTimeOffset? birthDate, 
            DateTimeOffset? deathDate, 
            string nationality,
            FileParameter image,
            bool keepExistingImage,
            BiographyDto biography,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Updating artist: {FirstName} {LastName}, ID: {ArtistId}", 
                    firstName, lastName, id);
                
                var biographyId = biography?.Id;
                var biographyContent = biography?.Content;
                var biographyShortDescription = biography?.ShortDescription;
                var biographyReferences = biography?.References;
                
                return await _client.ArtistsPUTAsync(
                    id,
                    apiVersion,
                    id, 
                    firstName,
                    lastName,
                    birthDate,
                    deathDate,
                    nationality,
                    image,
                    keepExistingImage,
                    biographyId,
                    biographyContent,
                    biographyShortDescription,
                    biographyReferences
                );
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error updating artist. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error updating artist ID {ArtistId}.", id);
                throw;
            }
        }

        public async Task<bool> DeleteArtistAsync(Guid id, string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Deleting artist ID: {ArtistId}", id);
                await _client.ArtistsDELETEAsync(id, apiVersion);
                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error deleting artist ID {ArtistId}. Status: {StatusCode}, Response: {Response}", id,
                    ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error deleting artist ID {ArtistId}.", id);
                return false;
            }
        }

        public async Task<bool> AddArtistToFavoritesAsync(Guid artistId, string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Adding artist ID {ArtistId} to favorites.", artistId);

                await _client.ArtistsPOSTAsync(artistId, apiVersion);

                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error adding artist ID {ArtistId} to favorites. Status: {StatusCode}, Response: {Response}",
                    artistId, ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error adding artist ID {ArtistId} to favorites.", artistId);
                return false;
            }
        }

        public async Task<UserFavoriteArtistsResponse> GetFavoriteArtistsAsync(string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching favorite artists for current user.");

                return await _client.ArtistsGETAsync(apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error fetching favorite artists. Status: {StatusCode}, Response: {Response}", ex.StatusCode,
                    ex.Response);
                return new UserFavoriteArtistsResponse
                { 
                    Success = false, 
                    Message = "API error occurred.", 
                    FavoriteArtists = new List<ArtistDto>()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching favorite artists.");
                return new UserFavoriteArtistsResponse
                {
                    Success = false, 
                    Message = "An unexpected error occurred.",
                    FavoriteArtists = new List<ArtistDto>()
                };
            }
        }
    }
}