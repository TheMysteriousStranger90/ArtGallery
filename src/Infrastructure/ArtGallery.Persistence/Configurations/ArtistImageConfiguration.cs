using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class ArtistImageConfiguration : IEntityTypeConfiguration<ArtistImage>
{
    public void Configure(EntityTypeBuilder<ArtistImage> builder)
    {
        builder.HasOne(ai => ai.Artist)
            .WithMany(a => a.ArtistImage)
            .HasForeignKey(ai => ai.ArtistId);
    }
}