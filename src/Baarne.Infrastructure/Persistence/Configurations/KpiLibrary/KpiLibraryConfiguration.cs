using System;
using Baarne.Domain.Entities.KpiLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.KpiLibrary;

public class KpiLibraryConfiguration : IEntityTypeConfiguration<Domain.Entities.KpiLibrary.KpiLibrary>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.KpiLibrary.KpiLibrary> builder)
    {
        builder.ToTable("kpi_library");

        builder.HasKey(k => k.Id);

        builder.Property(k => k.KpiName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(k => k.DataTypeId).IsRequired();
        builder.Property(k => k.TypeOfKpiId).IsRequired();
        builder.Property(k => k.MetricDescriptionId).IsRequired();
        builder.Property(k => k.AnalysisObjectiveId).IsRequired();
        builder.Property(k => k.StrategicAlignmentId).IsRequired();
        builder.Property(k => k.MeasurementFrequencyId).IsRequired();
        builder.Property(k => k.DepartmentFunctionId).IsRequired();
        builder.Property(k => k.OwnerResponsiblePersonId).IsRequired();
        builder.Property(k => k.DataSourceId).IsRequired();
        builder.Property(k => k.PlatformId).IsRequired();
        builder.Property(k => k.VisualizationOptionsId).IsRequired();
        builder.Property(k => k.PriorityLevelId).IsRequired();
        builder.Property(k => k.CategoryId).IsRequired();
        builder.Property(k => k.HistoricalDataAvailableId).IsRequired();
        builder.Property(k => k.TargetValueId).IsRequired();
        builder.Property(k => k.BenchmarkValueId).IsRequired();
        builder.Property(k => k.PerformanceTrendId).IsRequired();
        builder.Property(k => k.StatusId).IsRequired();
        builder.Property(k => k.ThresholdsAlertsId).IsRequired();
        builder.Property(k => k.DataUpdateFrequencyId).IsRequired();

        builder.HasOne(k => k.Company)
            .WithMany()
            .HasForeignKey(k => k.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(k => k.UserKpiPermissions)
            .WithOne(ukp => ukp.Kpi)
            .HasForeignKey(ukp => ukp.KpiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(k => k.KpiSelections)
            .WithOne()
            .HasForeignKey(ks => ks.SelectedKpiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(k => k.SelectedKpis)
            .WithOne(sk => sk.Kpi)
            .HasForeignKey(sk => sk.KpiId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(k => !k.IsDeleted);
    }
}

