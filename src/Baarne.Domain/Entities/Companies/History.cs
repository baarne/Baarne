using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Companies
{
    public class History : BaseEntity
    {
        public int CompanyId { get; set; }
        public string ActionType { get; set; }
        public string Description { get; set; }
        public DateTime ActionDate { get; set; }
        public string ActionBy { get; set; }

        public Company Company { get; set; }
    }
}
