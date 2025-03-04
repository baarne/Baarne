using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;
using Baarne.Domain.Entities.Feature;
using Baarne.Domain.Entities.Organization;

namespace Baarne.Domain.Entities.CurrentUser
{
    public class User : BaseEntity
    {
        //Kullanıcı bilgileri
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int CompanyId { get; set; }

        //Kullanıcı ile Company arasında ilişki (eğer kullanıcı şirkete bağlıysa)
        public Company Company { get; set; }
        public ICollection<UserPermission> UserPermissions { get; set; }
        public ICollection<UserKpiPermission> UserKpiPermissions { get; set; }
        public ICollection<UserFeedback> UserFeedbacks { get; set; }
        public ICollection<UserSelection> UserSelections { get; set; }
        public ICollection<PageInteraction> PageInteractions { get; set; }
        public ICollection<CustomBranchDetail> CustomBranchDetails { get; set; }
        public ICollection<CustomDepartmentDetail> CustomDepartmentDetails { get; set; }
        public ICollection<CustomEmployeeDetail> CustomEmployeeDetails { get; set; }
    }
}
