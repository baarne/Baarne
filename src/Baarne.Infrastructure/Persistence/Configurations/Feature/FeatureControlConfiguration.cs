using System;
using Baarne.Domain.Entities.Feature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Feature;

public class FeatureControlConfiguration : IEntityTypeConfiguration<FeatureControl>
{
    public void Configure(EntityTypeBuilder<FeatureControl> builder)
    {
        builder.ToTable("features_controls");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.FeatureName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(f => f.Status)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(f => f.Description)
            .HasColumnType("text");

        builder.HasOne(f => f.AdminRole)
            .WithMany()
            .HasForeignKey(f => f.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(f => f.PageActions)
            .WithOne(pa => pa.Feature)
            .HasForeignKey(pa => pa.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.PageInteractions)
            .WithOne(pi => pi.Feature)
            .HasForeignKey(pi => pi.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(f => !f.IsDeleted);
    }
}
