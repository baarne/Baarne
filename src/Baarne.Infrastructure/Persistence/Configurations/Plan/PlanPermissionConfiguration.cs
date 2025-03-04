using System;
using Baarne.Domain.Entities.Plan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Plan;

public class PlanPermissionConfiguration : IEntityTypeConfiguration<PlanPermission>
{
    public void Configure(EntityTypeBuilder<PlanPermission> builder)
    {
        builder.ToTable("plan_permissions");

        builder.HasKey(pp => pp.Id);

        builder.Property(pp => pp.PermissionName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(pp => pp.Description)
            .HasColumnType("text");

        builder.Property(pp => pp.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasOne(pp => pp.Plan)
            .WithMany(cpd => cpd.PlanPermissions)
            .HasForeignKey(pp => pp.PlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(pp => !pp.IsDeleted);
    }
}
