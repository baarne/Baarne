using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;
using Baarne.Domain.Entities.CurrentUser;

namespace Baarne.Domain.Entities.KpiLibrary
{
    public class KpiLibrary : BaseEntity
    {
        public int CompanyId { get; set; }
        public int AdminRoleId { get; set; }
        public string KpiName { get; set; }
        public int DataTypeId { get; set; }
        public int TypeOfKpiId { get; set; }
        public int MetricDescriptionId { get; set; }
        public int AnalysisObjectiveId { get; set; }
        public int StrategicAlignmentId { get; set; }
        public int MeasurementFrequencyId { get; set; }
        public int DepartmentFunctionId { get; set; }
        public int OwnerResponsiblePersonId { get; set; }
        public int DataSourceId { get; set; }
        public int PlatformId { get; set; }
        public int VisualizationOptionsId { get; set; }
        public int PriorityLevelId { get; set; }
        public int CategoryId { get; set; }
        public int HistoricalDataAvailableId { get; set; }
        public int TargetValueId { get; set; }
        public int BenchmarkValueId { get; set; }
        public int PerformanceTrendId { get; set; }
        public int StatusId { get; set; }
        public int ThresholdsAlertsId { get; set; }
        public int DataUpdateFrequencyId { get; set; }


        public Company Company { get; set; }
        public ICollection<UserKpiPermission> UserKpiPermissions { get; set; }
        public ICollection<KpiSelection> KpiSelections { get; set; }
        public ICollection<SelectedKpi> SelectedKpis { get; set; }
    }
}
