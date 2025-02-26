using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.KpiLibrary
{
    public class SelectedKpi : BaseEntity
    {
        public int KpiId { get; set; }
        public KpiLibrary Kpi { get; set; }

        public KpiTarget KpiTarget { get; set; }
        public ICollection<KpiSelection> KpiSelections { get; set; }
    }
}
