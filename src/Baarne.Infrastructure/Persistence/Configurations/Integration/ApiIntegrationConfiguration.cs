using System;
using Baarne.Domain.Entities.Integration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Integration;

public class ApiIntegrationConfiguration : IEntityTypeConfiguration<ApiIntegration>
{
    public void Configure(EntityTypeBuilder<ApiIntegration> builder)
    {
        builder.ToTable("api_integrations");

        builder.HasKey(ai => ai.Id);

        builder.Property(ai => ai.ApiName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ai => ai.IntegrationData)
            .IsRequired()
            .HasColumnType("jsonb");  // PostgreSQL'de JSON veri tipi için

        builder.Property(ai => ai.IntegrationDate)
            .IsRequired();

        builder.HasOne(ai => ai.Company)
            .WithMany(c => c.ApiIntegrations)
            .HasForeignKey(ai => ai.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(ai => !ai.IsDeleted);
    }
}
