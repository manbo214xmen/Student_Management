using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acess_Layer.Entities
{
    public class StudentEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string StudentPhone { get; set; }
        public int StudentAge { get; set; }
        public int CurrentGradeId { get; set; }
        public GradeEntity CurrentGrade { get; set; }
        public virtual ICollection<CourseEntity> Courses { get; set; }

        public StudentEntity()
        {
            this.Courses = new HashSet<CourseEntity>();
        }               
    }
}

