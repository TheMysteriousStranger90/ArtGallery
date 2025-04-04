using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class UserFavoritePaintingConfiguration : IEntityTypeConfiguration<UserFavoritePainting>
{
    public void Configure(EntityTypeBuilder<UserFavoritePainting> builder)
    {
        builder.HasKey(ufp => new { ufp.UserId, ufp.PaintingId });

        builder.HasOne(ufp => ufp.Painting)
            .WithMany(p => p.UserFavoritePaintings)
            .HasForeignKey(ufp => ufp.PaintingId)
            .OnDelete(DeleteBehavior.Cascade);

        // Note: The other side of this relationship is defined in Identity context
    }
}