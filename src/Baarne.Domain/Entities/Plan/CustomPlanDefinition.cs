using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;

namespace Baarne.Domain.Entities.Plan
{
    public class CustomPlanDefinition : BaseEntity
    {
        public string PlanName { get; set; }
        public decimal Fee { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Company> Companies { get; set; }
        public ICollection<PlanPermission> PlanPermissions { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
