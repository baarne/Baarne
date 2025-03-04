using System;
using Baarne.Domain.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Admin;

public class AdminActionConfiguration : IEntityTypeConfiguration<AdminAction>
{
    public void Configure(EntityTypeBuilder<AdminAction> builder)
    {
        builder.ToTable("AdminActions");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.ActionType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(a => a.ActionTime)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(a => a.TargetTable)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Details)
            .HasColumnType("text");

        // Relationships
        builder.HasOne(a => a.Admin)
            .WithMany(admin => admin.Actions)
            .HasForeignKey(a => a.AdminId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(a => a.Role)
            .WithMany(r => r.Actions)
            .HasForeignKey(a => a.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
