using System;
using System.Collections.Generic;

namespace Bussiness.DTO
{
    public class GradeComponentDTO
    {
        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public string? GradeCategory { get; set; }
        public string? GradeItem { get; set; }
        public bool? IsFinal { get; set; }
        public short? Weight { get; set; }
        public short? MinScore { get; set; }

        public virtual SubjectDTO? Subject { get; set; }
    }
}
