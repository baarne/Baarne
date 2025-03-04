using System;
using Baarne.Domain.Entities.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Organization;

public class CustomDepartmentDetailConfiguration : IEntityTypeConfiguration<CustomDepartmentDetail>
{
    public void Configure(EntityTypeBuilder<CustomDepartmentDetail> builder)
    {
        builder.ToTable("custom_department_details");

        builder.HasKey(cdd => cdd.Id);

        builder.Property(cdd => cdd.CustomName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(cdd => cdd.Location)
            .HasMaxLength(200);

        builder.Property(cdd => cdd.Description)
            .HasColumnType("text");

        builder.HasOne(cdd => cdd.User)
            .WithMany(u => u.CustomDepartmentDetails)
            .HasForeignKey(cdd => cdd.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cdd => cdd.Department)
            .WithMany(d => d.CustomDepartmentDetails)
            .HasForeignKey(cdd => cdd.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(cdd => cdd.UserSelections)
            .WithOne(us => us.CustomDepartment)
            .HasForeignKey(us => us.CustomDepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(cdd => !cdd.IsDeleted);
    }
}
