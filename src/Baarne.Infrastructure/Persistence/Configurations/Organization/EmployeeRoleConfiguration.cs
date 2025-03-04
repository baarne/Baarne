using System;
using Baarne.Domain.Entities.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Organization;

public class EmployeeRoleConfiguration : IEntityTypeConfiguration<EmployeeRole>
{
    public void Configure(EntityTypeBuilder<EmployeeRole> builder)
    {
        builder.ToTable("employee_roles");

        builder.HasKey(er => er.Id);

        builder.Property(er => er.RoleLevel)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(er => er.RoleTitle)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(er => er.AdminRole)
            .WithMany()
            .HasForeignKey(er => er.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(er => er.CustomEmployeeDetails)
            .WithOne(ced => ced.Employee)
            .HasForeignKey(ced => ced.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(er => !er.IsDeleted);
    }
}
