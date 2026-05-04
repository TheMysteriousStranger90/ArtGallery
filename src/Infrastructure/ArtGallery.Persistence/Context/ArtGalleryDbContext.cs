using System.Linq.Expressions;
using System.Reflection;
using ArtGallery.Application.Contracts;
using ArtGallery.Domain.Common;
using ArtGallery.Domain.Entities;
using ArtGallery.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Persistence.Context;

public class ArtGalleryDbContext : DbContext
{
    private readonly ILoggedInUserService _loggedInUserService;

    public DbSet<Artist> Artists { get; set; }
    public DbSet<Painting> Paintings { get; set; }
    public DbSet<Biography> Biographies { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Museum> Museums { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<PaintingTag> PaintingTags { get; set; }
    public DbSet<PaintingExhibition> PaintingExhibitions { get; set; }
    public DbSet<ArtistImage> ArtistImages { get; set; }
    public DbSet<PaintingImage> PaintingImages { get; set; }

    public ArtGalleryDbContext(DbContextOptions<ArtGalleryDbContext> options,
        ILoggedInUserService loggedInUserService)
        : base(options)
    {
        _loggedInUserService = loggedInUserService;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Ignore<ApplicationUser>();
        modelBuilder.Ignore<AppRole>();
        modelBuilder.Ignore<AppUserRole>();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        SeedDataInitializer.ContextSeed(modelBuilder);
        
        
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "e");
                var property = Expression.Property(parameter, nameof(BaseEntity.IsDeleted));
                var falseValue = Expression.Constant(false);
                var body = Expression.Equal(property, falseValue);
                var lambda = Expression.Lambda(body, parameter);

                modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
            }
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = _loggedInUserService.UserId;
                    break;
                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.UtcNow;
                    entry.Entity.LastModifiedBy = _loggedInUserService.UserId;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}