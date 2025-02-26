using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Admin
{
    public class AdminCompany : BaseEntity
    {
        public string CompanyName { get; set; }
        public int CustomPlanId { get; set; }
        public int AdminRoleId { get; set; }

        public AdminRole Role { get; set; }
        public AdminPlanDefinition CustomPlan { get; set; }
    }
}
