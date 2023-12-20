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
    public class StudentAddressDTO
    {
        [JsonIgnore]
        public int StudentAddressId { get; set; }

        [StringLength(50, ErrorMessage = "Student address should be less than 50 characters.")]
        public string Address1 { get; set; }
        [StringLength(50, ErrorMessage = "Student address should be less than 50 characters.")]
        public string? Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }

        [StringLength(20, ErrorMessage = "Country should be less than 20 characters.")]

        public string Country { get; set; }
        //[JsonIgnore]
        public int StudentId { get; set; }

    }
}
