using System.Collections;
using ArtGallery.Application.Contracts;
using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Domain.Common;
using ArtGallery.Persistence.Context;
using ArtGallery.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
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

      /// <summary>
        /// Gets a generic repository for the specified entity type.
        /// If the repository doesn't exist yet, it creates and caches a new instance.
        /// </summary>
        /// <typeparam name="TEntity">The entity type for which to get a repository</typeparam>
        /// <returns>A repository for the specified entity type</returns>
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

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Saves all changes made in this context to the database within a transaction.
        /// Begins a new transaction if one doesn't exist, saves changes, and commits the transaction.
        /// If an error occurs, the transaction is rolled back.
        /// 
        /// WARNING: This method is not compatible with SQL Server's retry execution strategy.
        /// Use ExecuteWithTransactionAsync methods instead when working with SQL Server in production.
        /// </summary>
        /// <returns>The number of state entries written to the database</returns>
        public async Task<int> CompleteWithTransaction()
        {
            var result = 0;

            try
            {
                if (_transaction == null)
                {
                    await BeginTransactionAsync();
                }

                result = await _context.SaveChangesAsync();
                await CommitTransactionAsync();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }

            return result;
        }

        /// <summary>
        /// Begins a new database transaction.
        /// If a transaction already exists, it reuses the existing one.
        /// 
        /// WARNING: This method is not compatible with SQL Server's retry execution strategy.
        /// Use ExecuteWithTransactionAsync methods instead when working with SQL Server in production.
        /// </summary>
        public async Task BeginTransactionAsync()
        {
            _transaction ??= await _context.Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Commits the current transaction and releases the underlying database transaction.
        /// This method ensures proper resource cleanup even if an exception occurs during commit.
        /// 
        /// WARNING: This method is not compatible with SQL Server's retry execution strategy.
        /// Use ExecuteWithTransactionAsync methods instead when working with SQL Server in production.
        /// </summary>
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

        /// <summary>
        /// Rolls back the current transaction and releases the underlying database transaction.
        /// This method ensures proper resource cleanup even if an exception occurs during rollback.
        /// 
        /// WARNING: This method is not compatible with SQL Server's retry execution strategy.
        /// Use ExecuteWithTransactionAsync methods instead when working with SQL Server in production.
        /// </summary>
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
        
        /// <summary>
        /// Executes the specified operation within a transaction using the database's execution strategy.
        /// This method is the recommended approach for transaction management, especially when:
        /// 1. Working with SQL Server (including Azure SQL) with retry policies
        /// 2. Requiring automatic retry for transient failures
        /// 3. Needing proper transaction and resource management
        /// 
        /// The operation is automatically retried based on the database provider's execution strategy,
        /// which helps handle transient failures in cloud environments.
        /// </summary>
        /// <param name="operation">The asynchronous operation to execute within the transaction</param>
        /// <remarks>
        /// Use this method instead of manually managing transactions with BeginTransactionAsync,
        /// CommitTransactionAsync, and RollbackTransactionAsync to ensure compatibility with
        /// SQL Server's retry execution strategy.
        /// </remarks>
        public async Task ExecuteWithTransactionAsync(Func<Task> operation)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
    
            await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    await operation();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        /// <summary>
        /// Executes the specified operation that returns a result within a transaction
        /// using the database's execution strategy.
        /// This method is the recommended approach for transaction management, especially when:
        /// 1. Working with SQL Server (including Azure SQL) with retry policies
        /// 2. Requiring automatic retry for transient failures
        /// 3. Needing proper transaction and resource management
        /// 4. Returning a result from the operation
        /// 
        /// The operation is automatically retried based on the database provider's execution strategy,
        /// which helps handle transient failures in cloud environments.
        /// </summary>
        /// <typeparam name="T">The type of result returned by the operation</typeparam>
        /// <param name="operation">The asynchronous operation to execute within the transaction</param>
        /// <returns>The result of the operation</returns>
        /// <remarks>
        /// Use this method instead of manually managing transactions with BeginTransactionAsync,
        /// CommitTransactionAsync, and RollbackTransactionAsync to ensure compatibility with
        /// SQL Server's retry execution strategy.
        /// </remarks>
        public async Task<T> ExecuteWithTransactionAsync<T>(Func<Task<T>> operation)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
    
            return await strategy.ExecuteAsync(async () =>
            {
                using var transaction = await _context.Database.BeginTransactionAsync();
                try
                {
                    var result = await operation();
                    await transaction.CommitAsync();
                    return result;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            });
        }

        /// <summary>
        /// Determines whether any changes have been made to entities in the current context.
        /// </summary>
        /// <returns>True if there are pending changes; otherwise, false</returns>
        public bool HasChanges()
        {
            return _context.ChangeTracker.HasChanges();
        }
        
        /// <summary>
        /// Disposes the context and transaction resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the UnitOfWork and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">True to release both managed and unmanaged resources; false to release only unmanaged resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}