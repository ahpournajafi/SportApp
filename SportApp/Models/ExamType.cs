using System;
using System.Collections.Generic;

namespace SportApp.Models
{
    public partial class ExamType
    {
        public ExamType()
        {
            Exams = new HashSet<Exam>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
