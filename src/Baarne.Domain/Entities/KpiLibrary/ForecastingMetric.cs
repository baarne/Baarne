using System;
using Baarne.Domain.Entities.Admin;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;

namespace Baarne.Domain.Entities.KpiLibrary
{
    public class ForecastingMetric : BaseEntity
    {
        public int CompanyId { get; set; }
        public string MetricName { get; set; }
        public string ForecastValue { get; set; }
        public DateTime ForecastDate { get; set; }
        public decimal ActualValue { get; set; }
        public int AdminRoleId { get; set; }

        public Company Company { get; set; }
        public AdminRole AdminRole { get; set; }
    }
}
