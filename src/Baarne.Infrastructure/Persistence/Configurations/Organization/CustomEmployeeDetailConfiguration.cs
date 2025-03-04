using System;
using Baarne.Domain.Entities.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Organization;

public class CustomEmployeeDetailConfiguration : IEntityTypeConfiguration<CustomEmployeeDetail>
{
    public void Configure(EntityTypeBuilder<CustomEmployeeDetail> builder)
    {
        builder.ToTable("custom_employee_details");

        builder.HasKey(ced => ced.Id);

        builder.Property(ced => ced.CustomTitle)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(ced => ced.Description)
            .HasColumnType("text");

        builder.HasOne(ced => ced.User)
            .WithMany()
            .HasForeignKey(ced => ced.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ced => ced.Employee)
            .WithMany()
            .HasForeignKey(ced => ced.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(ced => ced.UserSelections)
            .WithOne(us => us.CustomEmployee)
            .HasForeignKey(us => us.CustomEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(ced => !ced.IsDeleted);
    }
}
