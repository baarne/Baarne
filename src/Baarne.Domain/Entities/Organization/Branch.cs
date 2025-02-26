using System;
using Baarne.Domain.Entities.Admin;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Organization
{
    public class Branch : BaseEntity
    {
        public string BranchesName { get; set; }
        public string BranchesTypes { get; set; }
        public int AdminRoleId { get; set; }
        public string Branches { get; set; }

        public AdminRole AdminRole { get; set; }
        public ICollection<CustomBranchDetail> CustomBranchDetails { get; set; }
    }
}
