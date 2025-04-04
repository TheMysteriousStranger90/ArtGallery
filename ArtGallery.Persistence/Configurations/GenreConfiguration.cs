using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(g => g.Description)
            .HasMaxLength(500);

        builder.HasMany(g => g.Paintings)
            .WithOne(p => p.Genre)
            .HasForeignKey(p => p.GenreId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}