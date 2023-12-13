using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Acess_Layer.Entities;

namespace Business_Logic_Layer.DTOs
{
    public class GradeDTO
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }
        public ICollection<StudentEntity> Students { get; set; }
    }
}
