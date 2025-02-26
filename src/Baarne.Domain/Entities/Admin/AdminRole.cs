using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Admin
{
    public class AdminRole : BaseEntity
    {
        public string RoleName { get; set; }
        public int RolePermissionId { get; set; }

        public AdminRolePermission RolePermission { get; set; }
        public ICollection<Admin> Admins { get; set; }
        public ICollection<AdminAction> Actions { get; set; }
        public ICollection<AdminPageAction> PageActions { get; set; }
    }
}
