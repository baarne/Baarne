using System;
using Baarne.Domain.Entities.Notification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.Notification;

public class AlarmNotificationConfiguration : IEntityTypeConfiguration<AlarmNotification>
{
    public void Configure(EntityTypeBuilder<AlarmNotification> builder)
    {
        builder.ToTable("alarm_notifications");

        builder.HasKey(an => an.Id);

        builder.Property(an => an.NotificationType)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(an => an.NotificationData)
            .IsRequired()
            .HasColumnType("jsonb");  // PostgreSQL'de JSON veri tipi için (Bu notun amacı; PSQL'de 2 tip var biri json diğeri jsonb. jsonb verileri binary formatta saklar çünkü daha hızlı sorgulama yapar.)

        builder.Property(an => an.OpenedAt)
            .IsRequired();

        builder.HasOne(an => an.Company)
            .WithMany(c => c.AlarmNotifications)
            .HasForeignKey(an => an.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasQueryFilter(an => !an.IsDeleted);
    }
}
