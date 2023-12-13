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
    public class AddressService
    {
        private readonly AddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressService(AddressRepository addressRepository, IMapper mapper)
        {
            this._addressRepository = addressRepository;
            this._mapper = mapper;
        }


    }
}
