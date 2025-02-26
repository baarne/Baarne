using System;
using Baarne.Domain.Entities.Admin;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Organization
{
    public class Department : BaseEntity
    {
        public string DepartmentsName { get; set; }
        public int AdminRoleId { get; set; }
        public string Departments { get; set; }
        public string DepartmentsTypes { get; set; }

        public AdminRole AdminRole { get; set; }
        public ICollection<CustomDepartmentDetail> CustomDepartmentDetails { get; set; }
    }
}
