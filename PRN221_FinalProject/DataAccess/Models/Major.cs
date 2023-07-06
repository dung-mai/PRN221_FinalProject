using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Major
    {
        public Major()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? MajorName { get; set; }
        public string? MajorCode { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
