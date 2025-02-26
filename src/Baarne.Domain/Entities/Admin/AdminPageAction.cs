using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Feature;

namespace Baarne.Domain.Entities.Admin
{
    public class AdminPageAction : BaseEntity
    {
        public int AdminId { get; set; }
        public string PageName { get; set; }
        public string ActionType { get; set; }
        public int FeatureId { get; set; }
        public DateTime ActionTime { get; set; }
        public string Details { get; set; }
        public int AdminRoleId { get; set; }

        public Admin Admin { get; set; }
        public AdminRole Role { get; set; }
        public FeatureControl Feature { get; set; }
    }
}
