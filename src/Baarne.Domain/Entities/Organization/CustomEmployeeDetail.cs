using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.CurrentUser;

namespace Baarne.Domain.Entities.Organization
{
    public class CustomEmployeeDetail : BaseEntity
    {
        public int UserId { get; set; }
        public int EmployeeId { get; set; }
        public string CustomTitle { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        public EmployeeRole Employee { get; set; }
        public ICollection<UserSelection> UserSelections { get; set; }
    }
}
