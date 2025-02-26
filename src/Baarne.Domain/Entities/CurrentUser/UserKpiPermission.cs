using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.KpiLibrary;

namespace Baarne.Domain.Entities.CurrentUser
{
    public class UserKpiPermission : BaseEntity
    {
        public int UserId { get; set; }
        public int KpiId { get; set; }
        public bool CanView { get; set; }
        public DateTime? ValidUntil { get; set; }

        // Navigation properties
        public User User { get; set; }
        public KpiLibrary.KpiLibrary Kpi { get; set; }
    }
}
