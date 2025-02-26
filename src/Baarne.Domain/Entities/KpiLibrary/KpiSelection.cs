using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;

namespace Baarne.Domain.Entities.KpiLibrary
{
    public class KpiSelection : BaseEntity
    {
        public int CompanyId { get; set; }
        public int SelectedKpiId { get; set; }
        public DateTime SelectionDate { get; set; }

        public Company Company { get; set; }
        public SelectedKpi SelectedKpi { get; set; }
    }
}
