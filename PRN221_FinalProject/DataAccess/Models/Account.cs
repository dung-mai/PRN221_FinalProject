using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Account
    {
        public Account()
        {
            Students = new HashSet<Student>();
            SubjectOfClasses = new HashSet<SubjectOfClass>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Roleid { get; set; }
        public string? Phonenumber { get; set; }
        public bool? Gender { get; set; }
        public string IdCard { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Middlename { get; set; } = null!;
        public string? Address { get; set; }
        public string? Image { get; set; }
        public short Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<SubjectOfClass> SubjectOfClasses { get; set; }
    }
}
