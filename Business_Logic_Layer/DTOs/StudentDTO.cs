using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Data_Acess_Layer.Entities;

namespace Business_Logic_Layer.DTOs
{
    public class StudentDTO
    {
        [NotNull]
        [JsonIgnore]
        public int StudentId { get; set; }

        [NotNull]
        [Required]   
        [StringLength(50, ErrorMessage = "Student name should be less than 50 characters.")]
        public string StudentName { get; set; }

        [NotNull]
        [Required]
        public string StudentEmail { get; set; }

        //[StringLength(12,MinimumLength = 12, ErrorMessage = "Phone number should be less than 12 characters.")]
        public string StudentPhone { get; set; }

        [Range(1, 150, ErrorMessage = "Age must be between 1 and 150.")]
        public int StudentAge { get; set; }
        public int CurrentGradeId { get; set; }

    }
}
