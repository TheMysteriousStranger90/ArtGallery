using System.Collections;
using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Common;
using ArtGallery.Persistence.Context;
using ArtGallery.Persistence.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace ArtGallery.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArtGalleryDbContext _context;
        private Hashtable _repositories;
        private IDbContextTransaction _transaction;
        private bool _disposed;

        private IArtistRepository _artistRepository;
        private IPaintingRepository _paintingRepository;
        private IExhibitionRepository _exhibitionRepository;
        private IMuseumRepository _museumRepository;
        private IImageRepository _imageRepository;
        private IUserFavoritesRepository _userFavoritesRepository;

        public UnitOfWork(ArtGalleryDbContext context)
        {
            _context = context;
        }

        public IArtistRepository ArtistRepository =>
            _artistRepository ??= new ArtistRepository(_context);

        public IPaintingRepository PaintingRepository =>
            _paintingRepository ??= new PaintingRepository(_context);

        public IExhibitionRepository ExhibitionRepository =>
            _exhibitionRepository ??= new ExhibitionRepository(_context);

        public IMuseumRepository MuseumRepository =>
            _museumRepository ??= new MuseumRepository(_context);

        public IImageRepository ImageRepository =>
            _imageRepository ??= new ImageRepository(_context);

        public IUserFavoritesRepository UserFavoritesRepository =>
            _userFavoritesRepository ??= new UserFavoritesRepository(_context);

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(
                    repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity>)_repositories[type];
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> CompleteWithTransaction()
        {
            var result = 0;

            try
            {
                // Start transaction if one isn't already active
                if (_transaction == null)
                {
                    await BeginTransactionAsync();
                }

                // Save changes and commit
                result = await _context.SaveChangesAsync();
                await CommitTransactionAsync();
            }
            catch
            {
                // Rollback on exceptions
                await RollbackTransactionAsync();
                throw;
            }

            return result;
        }

        public async Task BeginTransactionAsync()
        {
            // Create new transaction if none exists
            _transaction ??= await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _transaction?.CommitAsync();
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _transaction?.RollbackAsync();
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }

        // IDisposable pattern implementation
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose transaction if active
                    _transaction?.Dispose();

                    // Dispose context
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}