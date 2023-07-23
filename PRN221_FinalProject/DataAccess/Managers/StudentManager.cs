using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Managers
{
    public class StudentManager
    {
        PRN221_ProjectContext _context;
        public StudentManager(PRN221_ProjectContext context)
        { 
            _context = context;
        }

        public Student? GetStudentWithGradeResults(int id)
        {
            return _context.Students.Include(s => s.Account)
                                    .Include(s => s.StudyCourses)
                                        .ThenInclude(course => course.SubjectResults)
                                    .Include(s => s.StudyCourses)
                                        .ThenInclude(course => course.SubjectOfClass)
                                        .ThenInclude(classSubject => classSubject.Subject)
                                    .Include(s => s.StudyCourses)
                                        .ThenInclude(course => course.SubjectOfClass)
                                        .ThenInclude(classSubject => classSubject.Class)
                                        .ThenInclude(c => c.Semester)
                                    .FirstOrDefault(s => s.AccountId == id);
        }
    }
}
