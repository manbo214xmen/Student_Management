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
    public class StudentAddressService
    {
        private readonly StudentAddressRepository _studentAddressRepository;
        private readonly IMapper _mapper;

        public StudentAddressService(StudentAddressRepository studentAddressRepository, IMapper mapper)
        {
            this._studentAddressRepository = studentAddressRepository;
            this._mapper = mapper;
        }


    }
}
