﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTO
{
    public class StudentDTO
    {
        [NotNull]
        public int StudentId { get; set; }
        [NotNull]
        public string StudentName { get; set; }
        [NotNull]
        public string GradeId { get; set; }
    }
}
