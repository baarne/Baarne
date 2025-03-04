using System;
using Baarne.Domain.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Admin;

public class AdminRolePermissionConfiguration : IEntityTypeConfiguration<AdminRolePermission>
{
    public void Configure(EntityTypeBuilder<AdminRolePermission> builder)
    {
        builder.ToTable("AdminRolePermissions");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Permissions)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(p => p.CanAdd)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(p => p.CanEdit)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(p => p.CanDelete)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(p => p.ValidUntil)
            .IsRequired();

        // Relationships
        builder.HasOne(p => p.Role)
            .WithOne(r => r.RolePermission)
            .HasForeignKey<AdminRolePermission>(p => p.AdminId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
