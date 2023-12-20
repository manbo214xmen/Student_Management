using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Data_Acess_Layer.Entities;

namespace Business_Logic_Layer.DTOs
{
    public class CourseDTO
    {
        [JsonIgnore]
        public int CourseId { get; set; }

        [StringLength(20, ErrorMessage = "Course name should be less than 20 characters.")]
        public string CourseName { get; set; }

        [StringLength(150, ErrorMessage = "Course description should be less than 150 characters.")]
        public string Description { get; set; }
    }
}
