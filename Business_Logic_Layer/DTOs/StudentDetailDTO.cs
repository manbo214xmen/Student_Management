using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.DTOs
{
    public class StudentDetailDTO
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        
        public string StudentEmail { get; set; }
        
        public string StudentPhone { get; set; }

        public int StudentAge { get; set; }
        public int CurrentGradeId { get; set; }

        // Include properties for Grade and Address
        public GradeDTO CurrentGrade { get; set; }
        public StudentAddressDTO Address { get; set; }
        //public CourseDTO Course { get; set; }
    }
}
