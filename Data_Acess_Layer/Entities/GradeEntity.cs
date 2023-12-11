using System;
using System.ComponentModel.DataAnnotations;

namespace Data_Acess_Layer.Entities
{
	public class GradeEntity
    {
        [Key]
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }
        public ICollection<StudentEntity> Students { get; set; }
    }
}

