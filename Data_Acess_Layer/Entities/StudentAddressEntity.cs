﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_Acess_Layer.Entities
{
	public class StudentAddressEntity
    {

        [Key]
        public int StudentAddressId { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [ForeignKey("AddressOfStudentId")]
        public int AddressOfStudentId { get; set; }

        public StudentEntity Student { get; set; }

    }
}

