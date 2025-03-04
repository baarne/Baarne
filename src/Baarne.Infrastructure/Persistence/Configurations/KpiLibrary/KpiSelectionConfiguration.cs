using System;
using Baarne.Domain.Entities.KpiLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.KpiLibrary;

public class KpiSelectionConfiguration : IEntityTypeConfiguration<KpiSelection>
{
    public void Configure(EntityTypeBuilder<KpiSelection> builder)
    {
        builder.ToTable("kpi_selections");

        builder.HasKey(ks => ks.Id);

        builder.Property(ks => ks.SelectionDate)
            .IsRequired();

        builder.HasOne(ks => ks.Company)
            .WithMany(c => c.KpiSelections)
            .HasForeignKey(ks => ks.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ks => ks.SelectedKpi)
            .WithMany()
            .HasForeignKey(ks => ks.SelectedKpiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(ks => !ks.IsDeleted);
    }
}
