using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;
using Baarne.Domain.Entities.Organization;

namespace Baarne.Domain.Entities.CurrentUser
{
    public class UserSelection : BaseEntity
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public int? CustomBranchId { get; set; }
        public int? CustomDepartmentId { get; set; }
        public int? CustomEmployeeId { get; set; }
        public DateTime SelectionDate { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
        public Company Company { get; set; }
        public CustomBranchDetail CustomBranch { get; set; }
        public CustomDepartmentDetail CustomDepartment { get; set; }
        public CustomEmployeeDetail CustomEmployee { get; set; }
    }
}
