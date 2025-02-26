using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Plan
{
    public class PlanPermission : BaseEntity
    {
        public int PlanId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public CustomPlanDefinition Plan { get; set; }
    }
}
