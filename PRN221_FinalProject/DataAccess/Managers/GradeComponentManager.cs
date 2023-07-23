using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Managers
{
    public class GradeComponentManager
    {
        PRN221_ProjectContext _context;
        public GradeComponentManager(PRN221_ProjectContext context)
        {
            _context = context;
        }

        public List<GradeComponent> GetGradeComponentsOfSubject(int subjectId)
        {
            return _context.GradeComponents
                .Where(c => c.SubjectId == subjectId)
                .ToList();
        }
    }
}
