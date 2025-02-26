using System;
using Baarne.Domain.Entities.Admin;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Plan
{
    public class Payment : BaseEntity
    {
        public int CompanyId { get; set; }
        public int PlanId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public int AdminRoleId { get; set; }

        public CustomPlanDefinition Plan { get; set; }
        public AdminRole AdminRole { get; set; }
    }
}
