using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.Services;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Entities;
using AutoMapper;

namespace Business_Logic_Layer.MappingProfile
{ 
    public class GradeMappingProfile :  Profile 
    {
        public GradeMappingProfile() 
        {
            CreateMap<GradeEntity, GradeDTO>().ReverseMap();
        }
    }

}
