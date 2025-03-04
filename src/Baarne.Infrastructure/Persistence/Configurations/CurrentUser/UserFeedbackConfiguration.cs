using System;
using Baarne.Domain.Entities.CurrentUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Baarne.Infrastructure.Persistence.Configurations.CurrentUser;

public class UserFeedbackConfiguration : IEntityTypeConfiguration<UserFeedback>
{
    public void Configure(EntityTypeBuilder<UserFeedback> builder)
    {
        builder.ToTable("UserFeedbacks");

        builder.HasKey(uf => uf.Id);

        builder.Property(uf => uf.FeedbackType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(uf => uf.FeedbackText)
            .IsRequired()
            .HasColumnType("text");

        builder.Property(uf => uf.Rating)
            .IsRequired();

        // Relationships
        builder.HasOne(uf => uf.User)
            .WithMany(u => u.UserFeedbacks)
            .HasForeignKey(uf => uf.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
