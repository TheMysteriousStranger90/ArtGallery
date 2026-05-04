using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class PaintingConfiguration : IEntityTypeConfiguration<Painting>
{
    public void Configure(EntityTypeBuilder<Painting> builder)
    {
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasMaxLength(2000);

        builder.Property(p => p.ImageUrl)
            .HasMaxLength(500);

        builder.Property(p => p.Medium)
            .HasMaxLength(100);

        builder.Property(p => p.Dimensions)
            .HasMaxLength(100);

        builder.HasOne(p => p.Artist)
            .WithMany(a => a.Paintings)
            .HasForeignKey(p => p.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Genre)
            .WithMany(g => g.Paintings)
            .HasForeignKey(p => p.GenreId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(p => p.Museum)
            .WithMany(m => m.Paintings)
            .HasForeignKey(p => p.MuseumId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(p => p.UserFavoritePaintings)
            .WithOne(fp => fp.Painting)
            .HasForeignKey(fp => fp.PaintingId);
    }
}