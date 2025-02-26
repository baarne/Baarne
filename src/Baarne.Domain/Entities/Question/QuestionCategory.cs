using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Question
{
    public class QuestionCategory : BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int OrderIndex { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
