using System;
using Baarne.Domain.Entities.Organization;
using Microsoft.EntityFrameworkCore;

namespace Baarne.Infrastructure.Persistence.Configurations.Organization;

public class CustomBranchDetailConfiguration : IEntityTypeConfiguration<CustomBranchDetail>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CustomBranchDetail> builder)
    {
        builder.ToTable("custom_branch_details");

        builder.HasKey(cbd => cbd.Id);

        builder.Property(cbd => cbd.CustomName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(cbd => cbd.Location)
            .HasMaxLength(200);

        builder.Property(cbd => cbd.Description)
            .HasColumnType("text");

        builder.HasOne(cbd => cbd.User)
            .WithMany(u => u.CustomBranchDetails)
            .HasForeignKey(cbd => cbd.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cbd => cbd.Branch)
            .WithMany(b => b.CustomBranchDetails)
            .HasForeignKey(cbd => cbd.BranchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(cbd => cbd.UserSelections)
            .WithOne(us => us.CustomBranch)
            .HasForeignKey(us => us.CustomBranchId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(cbd => !cbd.IsDeleted);
    }
}
