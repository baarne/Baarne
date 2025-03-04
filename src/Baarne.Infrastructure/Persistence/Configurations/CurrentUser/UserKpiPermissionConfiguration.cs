using System;
using Baarne.Domain.Entities.CurrentUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.CurrentUser;

public class UserKpiPermissionConfiguration : IEntityTypeConfiguration<UserKpiPermission>
{
    public void Configure(EntityTypeBuilder<UserKpiPermission> builder)
    {
        builder.ToTable("UserKpiPermissions");

        builder.HasKey(ukp => ukp.Id);

        builder.Property(ukp => ukp.CanView)
            .IsRequired()
            .HasDefaultValue(false);

        builder.Property(ukp => ukp.ValidUntil)
            .IsRequired(false);

        // Relationships
        builder.HasOne(ukp => ukp.User)
            .WithMany(u => u.UserKpiPermissions)
            .HasForeignKey(ukp => ukp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ukp => ukp.Kpi)
            .WithMany()
            .HasForeignKey(ukp => ukp.KpiId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
