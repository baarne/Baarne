using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;

namespace Baarne.Domain.Entities.Notification
{
    public class AlarmNotification : BaseEntity
    {
        public int CompanyId { get; set; }
        public string NotificationType { get; set; }
        public string NotificationData { get; set; } // JSON data
        public DateTime OpenedAt { get; set; }

        public Company Company { get; set; }
    }
}
