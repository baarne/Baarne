using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.KpiLibrary
{
    public class KpiTarget : BaseEntity
    {
        public int SelectionKpiId { get; set; }
        public decimal TargetValue { get; set; }
        public DateTime ValidForm { get; set; }
        public DateTime ValidUntil { get; set; }

        public SelectedKpi SelectionKpi { get; set; }
    }
}
