using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasMany(t => t.Paintings)
            .WithOne(pt => pt.Tag)
            .HasForeignKey(pt => pt.TagId);
    }
}