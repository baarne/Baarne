using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;

namespace Baarne.Domain.Entities.Integration
{
    public class ApiIntegration : BaseEntity
    {
        public int CompanyId { get; set; }
        public string ApiName { get; set; }
        public string IntegrationData { get; set; } // JSON data
        public DateTime IntegrationDate { get; set; }

        public Company Company { get; set; }
    }
}
