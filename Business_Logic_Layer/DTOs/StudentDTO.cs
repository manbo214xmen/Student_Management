using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Acess_Layer.Entities;

namespace Business_Logic_Layer.DTOs
{
    public class StudentDTO
    {
        [NotNull]
        public int StudentId { get; set; }
        [NotNull]
        public string StudentName { get; set; }
        [NotNull]
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public int StudentAge { get; set; }
        public int CurrentGradeId { get; set; }
    }
}
