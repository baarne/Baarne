using System;
using Baarne.Domain.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations;

public class AdminCompanyConfiguration : IEntityTypeConfiguration<AdminCompany>
{
    public void Configure(EntityTypeBuilder<AdminCompany> builder)
    {
        builder.ToTable("AdminCompanies");

        builder.HasKey(ac => ac.Id);

        builder.Property(ac => ac.CompanyName)
            .IsRequired()
            .HasMaxLength(200);

        // Relationships
        builder.HasOne(ac => ac.Role)
            .WithMany()
            .HasForeignKey(ac => ac.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ac => ac.CustomPlan)
            .WithMany()
            .HasForeignKey(ac => ac.CustomPlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
