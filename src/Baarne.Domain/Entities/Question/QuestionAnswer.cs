using System;
using Baarne.Domain.Entities.Common;
using Baarne.Domain.Entities.Companies;

namespace Baarne.Domain.Entities.Question
{
    public class QuestionAnswer : BaseEntity
    {
        public int QuestionId { get; set; }
        public int CompanyId { get; set; }
        public string AnswerText { get; set; }
        public decimal? NumericValue { get; set; }
        public bool? BooleanValue { get; set; }
        public DateTime AnswerDate { get; set; }

        public Question Question { get; set; }
        public Company Company { get; set; }
    }
}
