using System;
using Baarne.Domain.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Admin;

public class AdminPlanDefinitionConfiguration : IEntityTypeConfiguration<AdminPlanDefinition>
{
    public void Configure(EntityTypeBuilder<AdminPlanDefinition> builder)
    {
        builder.ToTable("AdminPlanDefinitions");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.PlanName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Fee)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(p => p.Description)
            .HasColumnType("text");

        builder.Property(p => p.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        // Relationships
        builder.HasOne(p => p.Role)
            .WithMany()
            .HasForeignKey(p => p.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(p => p.Companies)
            .WithOne(c => c.CustomPlan)
            .HasForeignKey(c => c.CustomPlanId);

        builder.HasMany(p => p.PlanPermissions)
            .WithOne(pp => pp.PlanDefiniton)
            .HasForeignKey(pp => pp.PlanId);
    }
}
