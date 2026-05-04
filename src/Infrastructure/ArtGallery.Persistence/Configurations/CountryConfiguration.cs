using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(c => c.Code)
            .IsRequired()
            .HasMaxLength(2);

        builder.HasMany(c => c.Cities)
            .WithOne(ci => ci.Country)
            .HasForeignKey(ci => ci.CountryId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasIndex(c => c.Code).IsUnique();
    }
}