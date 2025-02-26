using System;
using Baarne.Domain.Entities.Common;

namespace Baarne.Domain.Entities.Question
{
    public class Question : BaseEntity
    {
        public int QuestionCategoryId { get; set; }
        public string QuestionText { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public int OrderIndex { get; set; }

        public QuestionCategory Category { get; set; }
        public ICollection<QuestionAnswer> Answers { get; set; }
    }
}
