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
    public class StudentRepository : IStudentRepository
    {
        PRN221_ProjectContext _context;
        IMapper _mapper;

        public StudentRepository(PRN221_ProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public StudentDTO? GetStudentWithGradeResults(int accountId)
        {
            StudentManager manager = new StudentManager(_context);
            Student? student = manager.GetStudentWithGradeResults(accountId);
            return student is null ? null : _mapper.Map<StudentDTO>(student);
        }

    }
}
