using System;
using Baarne.Domain.Entities.CurrentUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.CurrentUser;

public class UserSelectionConfiguration : IEntityTypeConfiguration<UserSelection>
{
    public void Configure(EntityTypeBuilder<UserSelection> builder)
    {
        builder.ToTable("UserSelections");

        builder.HasKey(us => us.Id);

        builder.Property(us => us.SelectionDate)
            .IsRequired()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Relationships
        builder.HasOne(us => us.User)
            .WithMany(u => u.UserSelections)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(us => us.Company)
            .WithMany()
            .HasForeignKey(us => us.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(us => us.CustomBranch)
            .WithMany(cb => cb.UserSelections)
            .HasForeignKey(us => us.CustomBranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(us => us.CustomDepartment)
            .WithMany(cd => cd.UserSelections)
            .HasForeignKey(us => us.CustomDepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(us => us.CustomEmployee)
            .WithMany(ce => ce.UserSelections)
            .HasForeignKey(us => us.CustomEmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
