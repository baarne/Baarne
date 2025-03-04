using System;
using Baarne.Domain.Entities.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Companies;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("company");

        builder.HasKey(c => c.Id);

        // Required fields
        builder.Property(c => c.CompanyName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(c => c.NaceCode)
            .HasMaxLength(50);

        builder.Property(c => c.Country)
            .HasMaxLength(100);

        builder.Property(c => c.City)
            .HasMaxLength(100);

        // Relationships
        builder.HasOne(c => c.League)
            .WithMany()
            .HasForeignKey(c => c.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Plan)
            .WithMany(p => p.Companies)
            .HasForeignKey(c => c.PlanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Users)
            .WithOne(u => u.Company)
            .HasForeignKey(u => u.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(c => c.Histories)
            .WithOne(h => h.Company)
            .HasForeignKey(h => h.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.KpiSelections)
            .WithOne(ks => ks.Company)
            .HasForeignKey(ks => ks.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.QuestionAnswers)
            .WithOne(qa => qa.Company)
            .HasForeignKey(qa => qa.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.AlarmNotifications)
            .WithOne(an => an.Company)
            .HasForeignKey(an => an.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.ApiIntegrations)
            .WithOne(ai => ai.Company)
            .HasForeignKey(ai => ai.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.ForecastingMetrics)
            .WithOne(fm => fm.Company)
            .HasForeignKey(fm => fm.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(c => c.CompanyName)
            .IsUnique();

        // Query Filter
        builder.HasQueryFilter(c => !c.IsDeleted);
    }
}
