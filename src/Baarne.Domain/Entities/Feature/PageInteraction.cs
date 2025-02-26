using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.CurrentUser;

namespace Baarne.Domain.Entities.Feature
{
    public class PageInteraction : BaseEntity
    {
        public int UserId { get; set; }
        public int FeatureId { get; set; }
        public string InteractionType { get; set; }
        public DateTime InteractionTime { get; set; }
        public string InteractionDetails { get; set; }
        public string PageName { get; set; }

        // Navigation properties
        public User User { get; set; }
        public FeatureControl Feature { get; set; }
    }
}
