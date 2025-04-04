using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class PaintingImageConfiguration : IEntityTypeConfiguration<PaintingImage>
{
    public void Configure(EntityTypeBuilder<PaintingImage> builder)
    {
        builder.HasOne(pi => pi.Painting)
            .WithMany(p => p.PaintingImages)
            .HasForeignKey(pi => pi.PaintingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}