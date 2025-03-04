using System;
using Baarne.Domain.Entities.CurrentUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.CurrentUser;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolePermissions");

        builder.HasKey(rp => rp.Id);

        builder.Property(rp => rp.PermissionName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(rp => rp.Description)
            .HasColumnType("text");

        builder.Property(rp => rp.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        // Relationships
        builder.HasMany(rp => rp.UserPermissions)
            .WithOne(up => up.Permission)
            .HasForeignKey(up => up.PermissionId);
    }
}
