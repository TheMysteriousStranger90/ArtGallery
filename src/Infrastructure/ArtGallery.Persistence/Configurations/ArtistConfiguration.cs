using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.Property(a => a.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.LastName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Nationality)
            .HasMaxLength(50);

        builder.HasMany(a => a.Paintings)
            .WithOne(p => p.Artist)
            .HasForeignKey(p => p.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(a => a.Biography)
            .WithOne(b => b.Artist)
            .HasForeignKey<Biography>(b => b.ArtistId);

        builder.HasMany(a => a.ArtistImage)
            .WithOne(i => i.Artist)
            .HasForeignKey(i => i.ArtistId);

        builder.HasMany(a => a.UserFavoriteArtists)
            .WithOne(fa => fa.Artist)
            .HasForeignKey(fa => fa.ArtistId);
    }
}