using System;
using Baarne.Domain.Entities.KpiLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.KpiLibrary;

public class KpiTargetConfiguration : IEntityTypeConfiguration<KpiTarget>
{
    public void Configure(EntityTypeBuilder<KpiTarget> builder)
    {
        builder.ToTable("kpi_targets");

        builder.HasKey(kt => kt.Id);

        builder.Property(kt => kt.TargetValue)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(kt => kt.ValidFrom)
            .IsRequired();

        builder.Property(kt => kt.ValidUntil)
            .IsRequired();

        builder.HasOne(kt => kt.SelectionKpi)
            .WithOne(sk => sk.KpiTarget)
            .HasForeignKey<KpiTarget>(kt => kt.SelectionKpiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(kt => !kt.IsDeleted);
    }
}
