using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class UserFavoriteArtistConfiguration : IEntityTypeConfiguration<UserFavoriteArtist>
{
    public void Configure(EntityTypeBuilder<UserFavoriteArtist> builder)
    {
        builder.HasKey(ufa => new { ufa.UserId, ufa.ArtistId });

        builder.HasOne(ufa => ufa.Artist)
            .WithMany(a => a.UserFavoriteArtists)
            .HasForeignKey(ufa => ufa.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);

        // Note: The other side of this relationship is defined in Identity context
    }
}