using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Admin
{
    public class AdminPlanPermission : BaseEntity
    {
        public int PlanId { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public int AdminRoleId { get; set; }

        public AdminPlanDefinition PlanDefiniton { get; set; }
        public AdminRole Role { get; set; }
    }
}
