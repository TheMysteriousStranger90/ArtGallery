using ArtGallery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtGallery.Persistence.Configurations;

public class PaintingExhibitionConfiguration : IEntityTypeConfiguration<PaintingExhibition>
{
    public void Configure(EntityTypeBuilder<PaintingExhibition> builder)
    {
        builder.HasKey(pe => new { pe.PaintingId, pe.ExhibitionId });

        builder.HasOne(pe => pe.Painting)
            .WithMany(p => p.Exhibitions)
            .HasForeignKey(pe => pe.PaintingId);

        builder.HasOne(pe => pe.Exhibition)
            .WithMany(e => e.Paintings)
            .HasForeignKey(pe => pe.ExhibitionId);
    }
}