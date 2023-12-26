using Data_Acess_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.MappingProfiles;
using Data_Acess_Layer.Entities;
using Business_Logic_Layer.Validations;

namespace Business_Logic_Layer.Services
{
    public class GradeService
    {
        private readonly GradeRepository _gradeRepository;
        private readonly GradeValidation _gradeValidation;
        private readonly IMapper _mapper;

        public GradeService(GradeRepository gradeRepository, GradeValidation gradeValidation, IMapper mapper)
        {
            this._gradeRepository = gradeRepository;
            this._gradeValidation = gradeValidation;
            this._mapper = mapper;
        }

        public List<GradeDTO> Get()
        {
            return _mapper.Map<List<GradeDTO>>(_gradeRepository.Get());
        }


        public List<StudentDTO> GetStudentListByGradeId(int id)
        {
            _gradeValidation.ValidateGradeId(id);
            return _mapper.Map<List<StudentDTO>>(_gradeRepository.GetStudentListByGradeId(id));
        }


        //public List<StudentDTO> GetFilterStudent(string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{


        //    return mapper.Map<List<StudentDTO>>(studentRepository.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize));
        //}

        public GradeDTO Get(int id)
        {
            _gradeValidation.ValidateGradeId(id);
            return _mapper.Map<GradeDTO>(_gradeRepository.Get(id));
        }

        public void Post(GradeDTO grade)
        {
            _gradeValidation.ValidateGradeName(grade);
            _gradeRepository.Post(_mapper.Map<GradeEntity>(grade));
        }

        public bool Put(int id, GradeDTO grade)
        {
            _gradeValidation.ValidateGradeId(id);
            _gradeValidation.ValidateGradeName(grade);
            return _gradeRepository.Put(id, _mapper.Map<GradeEntity>(grade));
        }

        public bool Delete(int id)
        {
            return _gradeRepository.Delete(id);
        }
    }
}
