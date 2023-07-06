﻿using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class GradeComponent
    {
        public GradeComponent()
        {
            DetailScores = new HashSet<DetailScore>();
        }

        public int Id { get; set; }
        public int? SubjectId { get; set; }
        public string? GradeCategory { get; set; }
        public string? GradeItem { get; set; }
        public bool? IsFinal { get; set; }
        public short? Weight { get; set; }
        public short? MinScore { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual ICollection<DetailScore> DetailScores { get; set; }
    }
}
