using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Admin
{
    public class AdminPlanDefinition : BaseEntity
    {
        public string PlanName { get; set; }
        public decimal Fee { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int AdminRoleId { get; set; }

        public AdminRole Role { get; set; }
        public ICollection<AdminCompany> Companies { get; set; }
        public ICollection<AdminPlanPermission> PlanPermissions { get; set; }
    }
}
