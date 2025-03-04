using System;
using Baarne.Domain.Entities.KpiLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.KpiLibrary;

public class SelectedKpiConfiguration : IEntityTypeConfiguration<SelectedKpi>
{
    public void Configure(EntityTypeBuilder<SelectedKpi> builder)
    {
        builder.ToTable("selected_kpis");

        builder.HasKey(sk => sk.Id);

        builder.HasOne(sk => sk.Kpi)
            .WithMany(k => k.SelectedKpis)
            .HasForeignKey(sk => sk.KpiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sk => sk.KpiTarget)
            .WithOne(kt => kt.SelectionKpi)
            .HasForeignKey<KpiTarget>(kt => kt.SelectionKpiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(sk => sk.KpiSelections)
            .WithOne(ks => ks.SelectedKpi)
            .HasForeignKey(ks => ks.SelectedKpiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(sk => !sk.IsDeleted);
    }
}
