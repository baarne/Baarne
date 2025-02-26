using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Companies
{
    public class League : BaseEntity
    {
        public string LeagueName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Company> Companies { get; set; }
    }
}
