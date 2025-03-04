using System;
using Baarne.Domain.Entities.Organization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Organization;

public class BranchConfiguration : IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable("branches");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.BranchesName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(b => b.BranchesTypes)
            .HasMaxLength(100);

        builder.Property(b => b.Branches)
            .HasColumnType("text");

        builder.HasOne(b => b.AdminRole)
            .WithMany()
            .HasForeignKey(b => b.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(b => b.CustomBranchDetails)
            .WithOne(cbd => cbd.Branch)
            .HasForeignKey(cbd => cbd.BranchId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(b => !b.IsDeleted);
    }
}
