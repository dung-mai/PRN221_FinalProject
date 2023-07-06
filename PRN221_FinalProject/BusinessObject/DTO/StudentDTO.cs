using DataAccess.Models;
using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class StudentDTO
    {
        public StudentDTO()
        {
            StudyCourses = new HashSet<StudyCourseDTO>();
        }

        public string Rollnumber { get; set; } = null!;
        public int? MajorId { get; set; }
        public int? AccountId { get; set; }

        public virtual AccountDTO? Account { get; set; }
        public virtual MajorDTO? Major { get; set; }
        public virtual ICollection<StudyCourseDTO> StudyCourses { get; set; }
    }
}
