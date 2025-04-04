using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class BiographyConfiguration : IEntityTypeConfiguration<Biography>
{
    public void Configure(EntityTypeBuilder<Biography> builder)
    {
        builder.Property(b => b.Content)
            .IsRequired();

        builder.Property(b => b.ShortDescription)
            .HasMaxLength(500);

        builder.Property(b => b.References)
            .HasMaxLength(3000);

        builder.HasOne(b => b.Artist)
            .WithOne(a => a.Biography)
            .HasForeignKey<Biography>(b => b.ArtistId);
    }
}