using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Semester
    {
        public Semester()
        {
            SubjectOfClasses = new HashSet<SubjectOfClass>();
        }

        public int Id { get; set; }
        public short? Year { get; set; }
        public string? SemesterName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<SubjectOfClass> SubjectOfClasses { get; set; }
    }
}
