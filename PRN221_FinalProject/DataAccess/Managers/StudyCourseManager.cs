using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Managers
{
    public class StudyCourseManager
    {
        PRN221_ProjectContext _context;
        public StudyCourseManager(PRN221_ProjectContext context)
        {
            _context = context;
        }

        public List<StudyCourse> GetStudyCourseOfStudentBySemester(int semesterId, string rollNumber)
        {
            return _context.StudyCourses
                .Include(course => course.SubjectOfClass)
                    .ThenInclude(sc => sc.Class)
                .Where(course => course.Rollnumber == rollNumber &&
                                                        course.SubjectOfClass.Class.SemesterId == semesterId)
                                        .ToList();
        }


        public StudyCourse? GetStudyCourseOfStudentBySubject(int semesterId, string rollNumber, int courseId)
        {
            return _context.StudyCourses
               .Include(course => course.SubjectOfClass)
                   .ThenInclude(sc => sc.Class)
                .Include(course => course.SubjectResults)
               .FirstOrDefault(course => course.Rollnumber == rollNumber &&
                                                       course.SubjectOfClass.Class.SemesterId == semesterId
                                                       && course.SubjectOfClass.SubjectId == courseId);
        }
    }
}
