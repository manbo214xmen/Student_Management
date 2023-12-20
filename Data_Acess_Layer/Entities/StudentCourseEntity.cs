using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acess_Layer.Entities
{
    public class StudentCourseEntity
    {
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }

        public int CourseId { get; set; }
        public CourseEntity Course { get; set; }
    }
}
