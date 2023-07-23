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
    public class GradeComponentRepository : IGradeComponentRepository
    {
        PRN221_ProjectContext _context;
        IMapper _mapper;

        public GradeComponentRepository(PRN221_ProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GradeComponentDTO> GetGradeComponentsOfSubjetWithStudentResult(int? subjectId, int studyCourseId)
        {
            if (subjectId == null)
            {
                return new List<GradeComponentDTO>();
            }
            GradeComponentManager gradeComponentManager = new GradeComponentManager(_context);
            DetailScoreManager detailScoreManager = new DetailScoreManager(_context);
            List<DetailScore> detailScores = detailScoreManager.GetScoresByStudyResult(studyCourseId);

            List<GradeComponent> components = gradeComponentManager.GetGradeComponentsOfSubject((int)subjectId);
            List<GradeComponentDTO> componentDTOs = components.Select(c => _mapper.Map<GradeComponentDTO>(c)).ToList();
            return componentDTOs.Select(component =>
                                    {
                                        component.DetailScore = FindScoreOfGradeComponent(component.Id, detailScores);
                                        return component;
                                    })
                                .ToList();
        }

        private DetailScoreDTO? FindScoreOfGradeComponent(int componentId, List<DetailScore> detailScores)
        {
            DetailScore? detailScore = detailScores.FirstOrDefault(score => score.GradeComponentId == componentId);
            return detailScore == null ? null : _mapper.Map<DetailScoreDTO>(detailScore);
        }
    }
}
