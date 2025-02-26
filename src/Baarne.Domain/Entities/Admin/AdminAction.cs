using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Admin
{
    public class AdminAction : BaseEntity
    {
        public int AdminId { get; set; }
        public string ActionType { get; set; }
        public DateTime ActionTime { get; set; }
        public string TargetTable { get; set; }
        public string Details { get; set; }
        public int AdminRoleId { get; set; }

        public Admin Admin { get; set; }
        public AdminRole Role { get; set; }
    }
}
