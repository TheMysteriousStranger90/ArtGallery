using ArtGallery.ClientApp.Constants;

namespace ArtGallery.ClientApp.Services.Interfaces
{
    public interface IArtistService
    {
        Task<Pagination_1OfOfArtistDtoAndApplicationAnd_0AndCulture_neutralAndPublicKeyToken_null> GetArtistsAsync(
            int pageIndex = 1, int pageSize = 10, string search = "", string nationality = "", 
            string sort = "lastName", string apiVersion = Const.DefaultApiVersion);

        Task<ArtistDetailDto> GetArtistAsync(Guid id, string apiVersion = Const.DefaultApiVersion);

        Task<ICollection<string>> GetNationalitiesAsync(string apiVersion = Const.DefaultApiVersion);

        Task<CreateArtistDto> CreateArtistAsync(
            string firstName, string lastName, DateTimeOffset? birthDate, DateTimeOffset? deathDate, 
            string nationality, FileParameter image, string biographyContent, 
            string biographyShortDescription, string biographyReferences, 
            string apiVersion = Const.DefaultApiVersion);

        Task<ArtistDto> UpdateArtistAsync(
            Guid id,
            string firstName, 
            string lastName, 
            DateTimeOffset? birthDate, 
            DateTimeOffset? deathDate, 
            string nationality,
            FileParameter image,
            bool keepExistingImage,
            BiographyDto biography,
            string apiVersion = Const.DefaultApiVersion);
        
        Task<bool> DeleteArtistAsync(Guid id, string apiVersion = Const.DefaultApiVersion);

        Task<bool> AddArtistToFavoritesAsync(Guid artistId, string apiVersion = Const.DefaultApiVersion);

        Task<UserFavoriteArtistsResponse> GetFavoriteArtistsAsync(string apiVersion = Const.DefaultApiVersion);
    }
}