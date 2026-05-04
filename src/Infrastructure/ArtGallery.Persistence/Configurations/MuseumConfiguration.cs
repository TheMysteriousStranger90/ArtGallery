using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class MuseumConfiguration : IEntityTypeConfiguration<Museum>
{
    public void Configure(EntityTypeBuilder<Museum> builder)
    {
        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(m => m.Description)
            .HasMaxLength(2000);

        builder.Property(m => m.Address)
            .HasMaxLength(300);

        builder.Property(m => m.WebsiteUrl)
            .HasMaxLength(500);

        builder.HasOne(m => m.City)
            .WithMany(c => c.Museums)
            .HasForeignKey(m => m.CityId);

        builder.HasMany(m => m.Paintings)
            .WithOne(p => p.Museum)
            .HasForeignKey(p => p.MuseumId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}