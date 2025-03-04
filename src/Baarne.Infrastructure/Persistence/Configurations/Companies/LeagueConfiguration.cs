using System;
using Baarne.Domain.Entities.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Companies;

public class LeagueConfiguration : IEntityTypeConfiguration<League>
{
    public void Configure(EntityTypeBuilder<League> builder)
    {
        builder.ToTable("leagues");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.LeagueName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(l => l.Description)
            .HasColumnType("text");

        // Relationships
        builder.HasMany(l => l.Companies)
            .WithOne(c => c.League)
            .HasForeignKey(c => c.LeagueId)
            .OnDelete(DeleteBehavior.Restrict);

        // Query Filter
        builder.HasQueryFilter(l => !l.IsDeleted);
    }
}
