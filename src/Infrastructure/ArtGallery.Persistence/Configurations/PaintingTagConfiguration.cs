using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class PaintingTagConfiguration : IEntityTypeConfiguration<PaintingTag>
{
    public void Configure(EntityTypeBuilder<PaintingTag> builder)
    {
        builder.HasKey(pt => new { pt.PaintingId, pt.TagId });

        builder.HasOne(pt => pt.Painting)
            .WithMany(p => p.Tags)
            .HasForeignKey(pt => pt.PaintingId);

        builder.HasOne(pt => pt.Tag)
            .WithMany(t => t.Paintings)
            .HasForeignKey(pt => pt.TagId);
    }
}