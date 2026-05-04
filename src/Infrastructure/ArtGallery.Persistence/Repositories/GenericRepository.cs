using System.Linq.Expressions;
using ArtGallery.Application.Contracts.Persistence;
using ArtGallery.Application.Specifications.Interfaces;
using ArtGallery.Domain.Common;
using ArtGallery.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly ArtGalleryDbContext _context;
    private DbSet<T> _dbSet;

    public GenericRepository(ArtGalleryDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IReadOnlyList<T>> ListAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        /*
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        */
        
        var existingEntity = await _dbSet.FindAsync(entity.Id);
    
        if (existingEntity != null)
        {
            _context.Entry(existingEntity).State = EntityState.Detached;
        }

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task RemoveAsync(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetByConditionAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }
    
    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        if (spec == null)
        {
            return _context.Set<T>().AsQueryable();
        }

        var query = _context.Set<T>().AsQueryable();
        
        if (spec.Criteria != null)
        {
            query = query.Where(spec.Criteria);
        }
        
        if (spec.Includes != null)
        {
            query = spec.Includes.Aggregate(query, 
                (current, include) => include != null ? current.Include(include) : current);
        }
        
        // Add this section to handle complex includes
        if (spec.IncludeQueryBuilder != null)
        {
            query = spec.IncludeQueryBuilder(query);
        }
    
        if (spec.OrderBy != null)
        {
            query = query.OrderBy(spec.OrderBy);
        }
        else if (spec.OrderByDescending != null)
        {
            query = query.OrderByDescending(spec.OrderByDescending);
        }
    
        if (spec.IsPagingEnabled)
        {
            query = query.Skip(spec.Skip).Take(spec.Take);
        }

        return query;
    }
}