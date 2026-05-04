namespace ArtGallery.ClientApp.Services.Interfaces;

public interface IExhibitionsService
{
    Task<ICollection<ExhibitionDto>> GetAllExhibitionsAsync(Guid? museumId = null, string apiVersion = Constants.Const.DefaultApiVersion);
    Task<ICollection<ExhibitionDto>> GetCurrentExhibitionsAsync(string apiVersion = Constants.Const.DefaultApiVersion);
    Task<ICollection<ExhibitionDto>> GetPastExhibitionsAsync(string apiVersion = Constants.Const.DefaultApiVersion);
    Task<ICollection<ExhibitionDto>> GetUpcomingExhibitionsAsync(string apiVersion = Constants.Const.DefaultApiVersion);
    Task<ExhibitionDetailDto> GetExhibitionByIdAsync(Guid id, string apiVersion = Constants.Const.DefaultApiVersion);
    Task<ExhibitionDto> CreateExhibitionAsync(CreateExhibitionCommand command, string apiVersion = Constants.Const.DefaultApiVersion);
    Task<ExhibitionDto> UpdateExhibitionAsync(Guid id, UpdateExhibitionCommand command, string apiVersion = Constants.Const.DefaultApiVersion);
    Task<bool> DeleteExhibitionAsync(Guid id, string apiVersion = Constants.Const.DefaultApiVersion);
    Task<bool> AddPaintingToExhibitionAsync(Guid exhibitionId, Guid paintingId, string apiVersion = Constants.Const.DefaultApiVersion);
    Task<bool> RemovePaintingFromExhibitionAsync(Guid exhibitionId, Guid paintingId, string apiVersion = Constants.Const.DefaultApiVersion);
}