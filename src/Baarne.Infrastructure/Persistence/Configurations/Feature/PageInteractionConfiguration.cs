using System;
using Baarne.Domain.Entities.Feature;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Feature;

public class PageInteractionConfiguration : IEntityTypeConfiguration<PageInteraction>
{
    public void Configure(EntityTypeBuilder<PageInteraction> builder)
    {
        builder.ToTable("page_interactions");

        builder.HasKey(pi => pi.Id);

        builder.Property(pi => pi.InteractionType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(pi => pi.InteractionTime)
            .IsRequired();

        builder.Property(pi => pi.InteractionDetails)
            .HasColumnType("text");

        builder.Property(pi => pi.PageName)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(pi => pi.User)
            .WithMany(u => u.PageInteractions)
            .HasForeignKey(pi => pi.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pi => pi.Feature)
            .WithMany(f => f.PageInteractions)
            .HasForeignKey(pi => pi.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(pi => !pi.IsDeleted);
    }
}
