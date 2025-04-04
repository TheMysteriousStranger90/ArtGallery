using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Common;

namespace ArtGallery.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        IArtistRepository ArtistRepository { get; }
        IPaintingRepository PaintingRepository { get; }
        IExhibitionRepository ExhibitionRepository { get; }
        IMuseumRepository MuseumRepository { get; }
        IImageRepository ImageRepository { get; }
        IUserFavoritesRepository UserFavoritesRepository { get; }
        Task<int> Complete();
        Task<int> CompleteWithTransaction();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        bool HasChanges();
    }
}