using System;

namespace Baarne.Domain.Entities.Admin
{
    public class Admin
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AdminRoleId { get; set; }
        public DateTime? LastLogin { get; set; }

        public AdminRole Role { get; set; }
        public ICollection<AdminAction> Actions { get; set; }
        public ICollection<AdminPageAction> PageActions { get; set; }
    }
}
