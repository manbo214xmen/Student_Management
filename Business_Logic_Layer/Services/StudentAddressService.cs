using Data_Acess_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Entities;
using Business_Logic_Layer.Validations;

namespace Business_Logic_Layer.Services
{
    public class StudentAddressService
    {
        private readonly StudentAddressValidation _studentAddressValidation;
        private readonly StudentAddressRepository _studentAddressRepository;
        private readonly IMapper _mapper;

        public StudentAddressService(StudentAddressRepository studentAddressRepository, StudentAddressValidation studentAddressValidation,IMapper mapper)
        {
            this._studentAddressValidation = studentAddressValidation;
            this._studentAddressRepository = studentAddressRepository;
            this._mapper = mapper;
        }

        public List<StudentAddressDTO> Get()
        {

            return _mapper.Map<List<StudentAddressDTO>>(_studentAddressRepository.Get());
        }

        //public List<StudentDTO> GetFilterStudent(string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{


        //    return mapper.Map<List<StudentDTO>>(studentRepository.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize));
        //}

        public StudentAddressDTO Get(int id)
        {
            return _mapper.Map<StudentAddressDTO>(_studentAddressRepository.Get(id));
        }
        public void Post(StudentAddressDTO studentAddress)
        {
            _studentAddressValidation.ValidateStudentAddress(studentAddress);

            _studentAddressRepository.Post(_mapper.Map<StudentAddressEntity>(studentAddress));
        }
        public bool Put(int id, StudentAddressDTO studentAddress)
        {
            _studentAddressValidation.ValidateStudentAddress(studentAddress);

            return _studentAddressRepository.Put(id, _mapper.Map<StudentAddressEntity>(studentAddress));
        }
        public bool Delete(int id)
        {
            return _studentAddressRepository.Delete(id);

        }

    }
}
