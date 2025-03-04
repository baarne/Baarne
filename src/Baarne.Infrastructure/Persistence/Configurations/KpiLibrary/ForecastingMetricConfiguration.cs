using System;
using Baarne.Domain.Entities.KpiLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.KpiLibrary;

public class ForecastingMetricConfiguration : IEntityTypeConfiguration<ForecastingMetric>
{
    public void Configure(EntityTypeBuilder<ForecastingMetric> builder)
    {
        builder.ToTable("forecasting_metrics");

        builder.HasKey(fm => fm.Id);

        builder.Property(fm => fm.MetricName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(fm => fm.ForecastValue)
            .IsRequired();

        builder.Property(fm => fm.ForecastDate)
            .IsRequired();

        builder.Property(fm => fm.ActualValue)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        // Relationships
        builder.HasOne(fm => fm.Company)
            .WithMany(c => c.ForecastingMetrics)
            .HasForeignKey(fm => fm.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(fm => fm.AdminRole)
            .WithMany()
            .HasForeignKey(fm => fm.AdminRoleId)
            .OnDelete(DeleteBehavior.Restrict);

        // Query Filter
        builder.HasQueryFilter(fm => !fm.IsDeleted);
    }
}
