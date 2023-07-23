using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Managers
{
    public class DetailScoreManager
    {
        PRN221_ProjectContext _context;
        public DetailScoreManager(PRN221_ProjectContext context)
        {
            _context = context;
        }

        public List<DetailScore> GetScoresByStudyResult(int studyCourse) {
            return _context.DetailScores.Where(course => course.SubjectResult.StudyCourseId == studyCourse).ToList();
        }
    }
}
