using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.CurrentUser;
using Baarne.Domain.Entities.KpiLibrary;
using Baarne.Domain.Entities.Notification;
using Baarne.Domain.Entities.Integration;
using Baarne.Domain.Entities.Question;
using Baarne.Domain.Entities.Plan;

namespace Baarne.Domain.Entities.Companies
{
    public class Company : BaseEntity
    {
        public int LeagueId { get; set; }
        public int PlanId { get; set; }
        public string CompanyName { get; set; }
        public string NaceCode { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

        public League League { get; set; }
        public CustomPlanDefinition Plan { get; set; }

        public ICollection<User> Users { get; set; }
        public ICollection<History> Histories { get; set; }
        public ICollection<KpiSelection> KpiSelections { get; set; }
        public ICollection<QuestionAnswer> QuestionAnswers { get; set; }
        public ICollection<AlarmNotification> AlarmNotifications { get; set; }
        public ICollection<ApiIntegration> ApiIntegrations { get; set; }
        public ICollection<ForecastingMetric> ForecastingMetrics { get; set; }
    }
}