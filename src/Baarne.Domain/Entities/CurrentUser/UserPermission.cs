using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.CurrentUser
{
    public class UserPermission : BaseEntity
    {
        public int UserId { get; set; }
        public int PermissionId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ValidUntil { get; set; }

        public User User { get; set; }
        public RolePermission Permission { get; set; }
    }
}
