using AutoMapper;
using Business.IRepository;
using Bussiness.DTO;
using DataAccess.Managers;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class StudyCourseRepository : IStudyCourseRepository
    {
        PRN221_ProjectContext _context;
        IMapper _mapper;

        public StudyCourseRepository(PRN221_ProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public StudyCourseDTO? GetStudyCourseBySubject(int? semesterId, string rollnumber, int? courseId)
        {
            if(semesterId == null || courseId == null)
            {
                return null;
            }
            StudyCourseManager studyCourseManager = new StudyCourseManager(_context);
            return _mapper.Map<StudyCourseDTO>(studyCourseManager.GetStudyCourseOfStudentBySubject((int)semesterId, rollnumber, (int)courseId));
        }

        public List<StudyCourseDTO> GetStudyCourseOfStudentBySemester(int semesterId, string rollNumber)
        {
            StudyCourseManager studyCourseManager = new StudyCourseManager(_context);
            return studyCourseManager.GetStudyCourseOfStudentBySemester(semesterId, rollNumber)
                                        .Select(course => _mapper.Map<StudyCourseDTO>(course))
                                        .ToList();
        }
    }
}
