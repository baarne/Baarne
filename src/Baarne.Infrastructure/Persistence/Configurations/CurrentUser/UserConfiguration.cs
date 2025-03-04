using System;
using Baarne.Domain.Entities.CurrentUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.CurrentUser;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        // Primary Key
        builder.HasKey(u => u.Id);

        // Required fields
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(200);

        // Relationships
        builder.HasOne(u => u.Company)
            .WithMany(c => c.Users)
            .HasForeignKey(u => u.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(u => u.UserPermissions)
            .WithOne(up => up.User)
            .HasForeignKey(up => up.UserId);

        builder.HasMany(u => u.UserKpiPermissions)
            .WithOne(ukp => ukp.User)
            .HasForeignKey(ukp => ukp.UserId);

        builder.HasMany(u => u.UserFeedbacks)
            .WithOne(uf => uf.User)
            .HasForeignKey(uf => uf.UserId);

        builder.HasMany(u => u.UserSelections)
            .WithOne(us => us.User)
            .HasForeignKey(us => us.UserId);

        // Indexes
        builder.HasIndex(u => u.Email)
            .IsUnique();

        // Query Filter for Soft Delete
        builder.HasQueryFilter(u => !u.IsDeleted);
    }
}
