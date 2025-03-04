using System;
using Baarne.Domain.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Admin;

public class AdminPageActionConfiguration : IEntityTypeConfiguration<AdminPageAction>
{
    public void Configure(EntityTypeBuilder<AdminPageAction> builder)
    {
        builder.ToTable("AdminPageActions");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.PageName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.ActionType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.ActionTime)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(a => a.Details)
            .HasColumnType("text");

        // Relationships
        builder.HasOne(a => a.Admin)
            .WithMany(admin => admin.PageActions)
            .HasForeignKey(a => a.AdminId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Role)
            .WithMany(r => r.PageActions)
            .HasForeignKey(a => a.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Feature)
            .WithMany()
            .HasForeignKey(a => a.FeatureId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
