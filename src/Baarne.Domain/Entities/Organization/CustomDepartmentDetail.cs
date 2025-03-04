using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.CurrentUser;

namespace Baarne.Domain.Entities.Organization
{
    public class CustomDepartmentDetail : BaseEntity
    {
        public int UserId { get; set; }
        public int DepartmentId { get; set; }
        public string CustomName { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        public Department Department { get; set; }
        public ICollection<UserSelection> UserSelections { get; set; }
    }
}
