using ArtGallery.ClientApp.Services.Interfaces;
using ArtGallery.ClientApp.Constants;

namespace ArtGallery.ClientApp.Services
{
    public class ExhibitionsService : IExhibitionsService
    {
        private readonly IClient _client;
        private readonly ILogger<ExhibitionsService> _logger;

        public ExhibitionsService(IClient client, ILogger<ExhibitionsService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ICollection<ExhibitionDto>> GetAllExhibitionsAsync(Guid? museumId = null,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching all exhibitions with museumId filter: {MuseumId}", museumId);
                return await _client.ExhibitionsAllAsync(museumId, apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error fetching all exhibitions. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);
                return new List<ExhibitionDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching all exhibitions.");
                return new List<ExhibitionDto>();
            }
        }

        public async Task<ICollection<ExhibitionDto>> GetCurrentExhibitionsAsync(
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching current exhibitions");
                return await _client.CurrentAsync(apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error fetching current exhibitions. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);
                return new List<ExhibitionDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching current exhibitions.");
                return new List<ExhibitionDto>();
            }
        }

        public async Task<ICollection<ExhibitionDto>> GetPastExhibitionsAsync(
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching past exhibitions");
                return await _client.PastAsync(apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error fetching past exhibitions. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);
                return new List<ExhibitionDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching past exhibitions.");
                return new List<ExhibitionDto>();
            }
        }

        public async Task<ICollection<ExhibitionDto>> GetUpcomingExhibitionsAsync(
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching upcoming exhibitions");
                return await _client.UpcomingAsync(apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error fetching upcoming exhibitions. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);
                return new List<ExhibitionDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching upcoming exhibitions.");
                return new List<ExhibitionDto>();
            }
        }

        public async Task<ExhibitionDetailDto> GetExhibitionByIdAsync(Guid id,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Fetching exhibition details for ID: {ExhibitionId}", id);
                return await _client.ExhibitionsGETAsync(id, apiVersion);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error fetching exhibition details for ID {ExhibitionId}. Status: {StatusCode}, Response: {Response}",
                    id, ex.StatusCode, ex.Response);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error fetching exhibition details for ID {ExhibitionId}.", id);
                return null;
            }
        }

        public async Task<ExhibitionDto> CreateExhibitionAsync(CreateExhibitionCommand command,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Creating new exhibition: {Title}", command.Title);
                return await _client.ExhibitionsPOSTAsync(apiVersion, command);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex, "API error creating exhibition. Status: {StatusCode}, Response: {Response}",
                    ex.StatusCode, ex.Response);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error creating exhibition.");
                throw;
            }
        }

        public async Task<ExhibitionDto> UpdateExhibitionAsync(Guid id, UpdateExhibitionCommand command,
            string apiVersion = Const.DefaultApiVersion)
        {
            if (id != command.Id)
            {
                _logger.LogError("Mismatched IDs in UpdateExhibitionAsync. Route ID: {ExhibitionId}, Body ID: {Id}", id,
                    command.Id);
                throw new ArgumentException("The ID in the URL must match the ID in the request body content.");
            }

            try
            {
                _logger.LogInformation("Updating exhibition with ID: {ExhibitionId}", id);
                return await _client.ExhibitionsPUTAsync(id, apiVersion, command);
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error updating exhibition ID {ExhibitionId}. Status: {StatusCode}, Response: {Response}",
                    id, ex.StatusCode, ex.Response);
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error updating exhibition ID {ExhibitionId}.", id);
                throw;
            }
        }

        public async Task<bool> DeleteExhibitionAsync(Guid id, string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Deleting exhibition with ID: {ExhibitionId}", id);
                await _client.ExhibitionsDELETEAsync(id, apiVersion);
                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error deleting exhibition ID {ExhibitionId}. Status: {StatusCode}, Response: {Response}",
                    id, ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error deleting exhibition ID {ExhibitionId}.", id);
                return false;
            }
        }

        public async Task<bool> AddPaintingToExhibitionAsync(Guid exhibitionId, Guid paintingId,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Adding painting {PaintingId} to exhibition {ExhibitionId}", paintingId,
                    exhibitionId);
                await _client.PaintingsPOSTAsync(exhibitionId, paintingId, apiVersion);
                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error adding painting {PaintingId} to exhibition {ExhibitionId}. Status: {StatusCode}, Response: {Response}",
                    paintingId, exhibitionId, ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error adding painting {PaintingId} to exhibition {ExhibitionId}.",
                    paintingId, exhibitionId);
                return false;
            }
        }

        public async Task<bool> RemovePaintingFromExhibitionAsync(Guid exhibitionId, Guid paintingId,
            string apiVersion = Const.DefaultApiVersion)
        {
            try
            {
                _logger.LogInformation("Removing painting {PaintingId} from exhibition {ExhibitionId}", paintingId,
                    exhibitionId);
                await _client.PaintingsDELETEAsync(exhibitionId, paintingId, apiVersion);
                return true;
            }
            catch (ApiException ex)
            {
                _logger.LogError(ex,
                    "API error removing painting {PaintingId} from exhibition {ExhibitionId}. Status: {StatusCode}, Response: {Response}",
                    paintingId, exhibitionId, ex.StatusCode, ex.Response);
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Generic error removing painting {PaintingId} from exhibition {ExhibitionId}.",
                    paintingId, exhibitionId);
                return false;
            }
        }
    }
}