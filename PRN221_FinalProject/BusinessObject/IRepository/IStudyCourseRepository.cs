using Bussiness.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IRepository
{
    public interface IStudyCourseRepository
    {
        StudyCourseDTO? GetStudyCourseBySubject(int? semesterId, string rollnumber, int? courseId);
        List<StudyCourseDTO> GetStudyCourseOfStudentBySemester(int semesterId, string rollNumber);
    }
}
