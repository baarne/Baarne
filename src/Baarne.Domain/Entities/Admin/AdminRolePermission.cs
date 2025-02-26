using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Admin
{
    public class AdminRolePermission : BaseEntity
    {
        public string Permissions { get; set; }
        public bool CanAdd { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
        public DateTime ValidUntil { get; set; }
        public int AdminId { get; set; }

        public AdminRole Role { get; set; }
    }
}
