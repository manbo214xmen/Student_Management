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
    public class StudentService
    {
        private readonly StudentRepository _studentRepository;
        private readonly StudentValidation _studentValidation;
        private readonly IMapper _mapper;
        public StudentService(StudentRepository studentRepository, IMapper mapper, StudentValidation studentValidation)
        {
            this._studentRepository = studentRepository;
            this._studentValidation = studentValidation;
            this._mapper = mapper;
        }

        public List<StudentDTO> Get()
        { 
            return _mapper.Map<List<StudentDTO>>(_studentRepository.Get());
        }

        //public List<StudentDTO> GetFilterStudent(string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{


        //    return mapper.Map<List<StudentDTO>>(studentRepository.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize));
        //}

        public StudentDetailDTO GetStudentWithDetailsById(int studentId)
        {
            var studentWithDetails = _studentRepository.GetStudentWithDetailsById(studentId);
            return _mapper.Map<StudentDetailDTO>(studentWithDetails);
        }
        public StudentDTO Get(int id)
        {
            return _mapper.Map<StudentDTO>(_studentRepository.Get(id));
        }

        public void Post(StudentDTO student)
        {
            _studentValidation.ValidateStudent(student);

            _studentRepository.Post(_mapper.Map<StudentEntity>(student));
        }

        public bool Put(int id, StudentDTO student)
        {
            _studentValidation.ValidateStudent(student);

            return _studentRepository.Put(id, _mapper.Map<StudentEntity>(student));
        }
        public bool Delete(int id)
        {
            return _studentRepository.Delete(id);

        }
    }
}
