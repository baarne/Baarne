using System;
using Baarne.Domain.Entities.Admin;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Feature
{
    public class FeatureControl : BaseEntity
    {
        public string FeatureName { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int AdminRoleId { get; set; }

        public AdminRole AdminRole { get; set; }
        public ICollection<AdminPageAction> PageActions { get; set; }
        public ICollection<PageInteraction> PageInteractions { get; set; }
    }
}
