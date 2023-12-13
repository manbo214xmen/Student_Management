using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Acess_Layer.Entities;

namespace Business_Logic_Layer.DTOs
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<StudentEntity> Students { get; set; }
        
    }
}
