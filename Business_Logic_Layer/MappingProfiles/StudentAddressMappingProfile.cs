using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Entities;

namespace Business_Logic_Layer.MappingProfiles
{
    public class StudentAddressMappingProfile : Profile
    {
        public StudentAddressMappingProfile()
        {
            CreateMap<StudentAddressEntity, StudentAddressDTO>().ReverseMap();
        }
    }
}
