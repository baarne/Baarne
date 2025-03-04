using System;
using Baarne.Domain.Entities.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Organization;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("departments");

        builder.HasKey(d => d.Id);

        builder.Property(d => d.DepartmentsName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(d => d.Departments)
            .HasColumnType("text");

        builder.Property(d => d.DepartmentsTypes)
            .HasMaxLength(100);

        builder.HasOne(d => d.AdminRole)
            .WithMany()
            .HasForeignKey(d => d.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(d => d.CustomDepartmentDetails)
            .WithOne(cdd => cdd.Department)
            .HasForeignKey(cdd => cdd.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(d => !d.IsDeleted);
    }
}
