using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Identity.Configurations;

public class UserFavoritePaintingConfiguration : IEntityTypeConfiguration<UserFavoritePainting>
{
    public void Configure(EntityTypeBuilder<UserFavoritePainting> builder)
    {
        builder.HasKey(ufp => new { ufp.UserId, ufp.PaintingId });
            
        builder.HasOne(ufp => ufp.User)
            .WithMany(u => u.FavoritePaintings)
            .HasForeignKey(ufp => ufp.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(ufp => ufp.Painting)
            .WithMany(p => p.UserFavoritePaintings)
            .HasForeignKey(ufp => ufp.PaintingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}