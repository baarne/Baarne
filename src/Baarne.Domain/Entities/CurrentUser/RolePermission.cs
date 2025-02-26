using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.CurrentUser
{
    public class RolePermission : BaseEntity
    {
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<UserPermission> UserPermissions { get; set; }
    }
}
