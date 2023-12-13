using System;
using System.ComponentModel.DataAnnotations;
namespace Data_Acess_Layer.Entities
{
	public class AddressEntity
    {
        [Key]
		public int AdressId { get; set; }      
        public string Address { get; set; }
        public string City { get; set; }    
        public int Zipcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}

