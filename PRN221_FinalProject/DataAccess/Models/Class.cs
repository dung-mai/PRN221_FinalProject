using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Class
    {
        public Class()
        {
            SubjectOfClasses = new HashSet<SubjectOfClass>();
        }

        public int Id { get; set; }
        public string? ClassName { get; set; }
        public int? SemesterId { get; set; }

        public virtual Semester? Semester { get; set; }
        public virtual ICollection<SubjectOfClass> SubjectOfClasses { get; set; }
    }
}
