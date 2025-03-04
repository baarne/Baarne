using System;
using Baarne.Domain.Entities.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Companies;

public class HistoryConfiguration : IEntityTypeConfiguration<History>
{
    public void Configure(EntityTypeBuilder<History> builder)
    {
        builder.ToTable("histories");

        builder.HasKey(h => h.Id);

        builder.Property(h => h.ActionType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(h => h.Description)
            .HasColumnType("text");

        builder.Property(h => h.ActionDate)
            .IsRequired();

        builder.Property(h => h.ActionBy)
            .IsRequired()
            .HasMaxLength(100);

        // Relationships
        builder.HasOne(h => h.Company)
            .WithMany(c => c.Histories)
            .HasForeignKey(h => h.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        // Query Filter
        builder.HasQueryFilter(h => !h.IsDeleted);
    }
}
