using System;
using Baarne.Domain.Entities.Plan;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Plan;

public class CustomPlanDefinitionConfiguration : IEntityTypeConfiguration<CustomPlanDefinition>
{
    public void Configure(EntityTypeBuilder<CustomPlanDefinition> builder)
    {
        builder.ToTable("custom_plan_definitions");

        builder.HasKey(cpd => cpd.Id);

        builder.Property(cpd => cpd.PlanName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(cpd => cpd.Fee)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(cpd => cpd.Description)
            .HasColumnType("text");

        builder.Property(cpd => cpd.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasMany(cpd => cpd.Companies)
            .WithOne(c => c.Plan)
            .HasForeignKey(c => c.PlanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(cpd => cpd.PlanPermissions)
            .WithOne(pp => pp.Plan)
            .HasForeignKey(pp => pp.PlanId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(cpd => cpd.Payments)
            .WithOne(p => p.Plan)
            .HasForeignKey(p => p.PlanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(cpd => !cpd.IsDeleted);
    }
}
