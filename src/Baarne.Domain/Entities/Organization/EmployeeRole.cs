using System;
using Baarne.Domain.Entities.Admin;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Organization
{
    public class EmployeeRole : BaseEntity
    {
        public string RoleLevel { get; set; }
        public string RoleTitle { get; set; }
        public int AdminRoleId { get; set; }

        public AdminRole AdminRole { get; set; }
        public ICollection<CustomEmployeeDetail> CustomEmployeeDetails { get; set; }
    }
}
