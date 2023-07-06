using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class SubjectResultDTO
    {
        public SubjectResultDTO()
        {
            DetailScores = new HashSet<DetailScoreDTO>();
        }

        public int Id { get; set; }
        public int? StudyCourseId { get; set; }
        public double? AverageMark { get; set; }
        public bool? Status { get; set; }
        public string? Note { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int UpdatedBy { get; set; }

        public virtual StudyCourseDTO? StudyCourse { get; set; }
        public virtual ICollection<DetailScoreDTO> DetailScores { get; set; }
    }
}
