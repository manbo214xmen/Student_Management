using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Acess_Layer.Entities;
using Newtonsoft.Json;

namespace Business_Logic_Layer.DTOs
{
    public class StudentAddressDTO
    {
        public int StudentAddressId { get; set; }
        public string Address1 { get; set; }
        public string? Address2 { get; set; }
        public string City { get; set; }
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int StudentId { get; set; }

    }
}
