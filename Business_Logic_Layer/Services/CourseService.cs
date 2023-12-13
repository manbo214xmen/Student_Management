using Data_Acess_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Entities;


namespace Business_Logic_Layer.Services
{
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseService(CourseRepository courseRepository, IMapper mapper)
        {
            this._courseRepository = courseRepository;
            this._mapper = mapper;
        }


    }
}
