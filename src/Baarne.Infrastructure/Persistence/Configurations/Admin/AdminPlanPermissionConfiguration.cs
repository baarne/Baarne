using System;
using Baarne.Domain.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Admin;

public class AdminPlanPermissionConfiguration : IEntityTypeConfiguration<AdminPlanPermission>
{
    public void Configure(EntityTypeBuilder<AdminPlanPermission> builder)
    {
        builder.ToTable("AdminPlanPermissions");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.PermissionName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Description)
            .HasColumnType("text");

        // Relationships
        builder.HasOne(p => p.PlanDefiniton)
            .WithMany(plan => plan.PlanPermissions)
            .HasForeignKey(p => p.PlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(p => p.Role)
            .WithMany()
            .HasForeignKey(p => p.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
