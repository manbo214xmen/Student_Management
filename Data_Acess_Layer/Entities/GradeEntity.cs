using System;

namespace Data_Acess_Layer.Entities
{
	public class GradeEntity
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }
        public ICollection<StudentEntity> Students { get; set; }
    }
}

