using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Identity.Configurations;

public class UserFavoriteArtistConfiguration : IEntityTypeConfiguration<UserFavoriteArtist>
{
    public void Configure(EntityTypeBuilder<UserFavoriteArtist> builder)
    {
        builder.HasKey(ufa => new { ufa.UserId, ufa.ArtistId });
            
        builder.HasOne(ufa => ufa.User)
            .WithMany(u => u.FavoriteArtists)
            .HasForeignKey(ufa => ufa.UserId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(ufa => ufa.Artist)
            .WithMany(a => a.UserFavoriteArtists)
            .HasForeignKey(ufa => ufa.ArtistId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}