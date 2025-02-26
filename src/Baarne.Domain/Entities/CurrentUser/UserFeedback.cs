using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.CurrentUser
{
    public class UserFeedback : BaseEntity
    {
        public int UserId { get; set; }
        public string FeedbackType { get; set; }
        public string FeedbackText { get; set; }
        public int Rating { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
    }
}
