using System;

namespace Baarne.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        //Audit Fields
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }

        // Soft Delete fileds
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }

        //Soft Delete Operation
        public virtual void SoftDetete(string userId)
        {
            IsDeleted = true;
            DeletedAt = DateTime.UtcNow;
            DeletedBy = userId;
        }

        //Restore Operation
        public virtual void Restore()
        {
            IsDeleted = false;
            DeletedAt = null;
            DeletedBy = null;
        }

    }
}
