using Data_Acess_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Logic_Layer.DTOs;
using Business_Logic_Layer.MappingProfile;
using Data_Acess_Layer.Entities;


namespace Business_Logic_Layer.Services
{
    public class GradeService
    {
        private readonly GradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(GradeRepository gradeRepository, IMapper mapper)
        {
            this._gradeRepository = gradeRepository;
            this._mapper = mapper;
        }

        public List<GradeDTO> Get()
        {
            return _mapper.Map<List<GradeDTO>>(_gradeRepository.Get());
        }

        //public List<StudentDTO> GetFilterStudent(string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{


        //    return mapper.Map<List<StudentDTO>>(studentRepository.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize));
        //}

        public GradeDTO Get(int id)
        { 
            return _mapper.Map<GradeDTO>(_gradeRepository.Get(id));
        }

        public void Post(GradeDTO grade)
        {
            _gradeRepository.Post(_mapper.Map<GradeEntity>(grade));
        }

        public bool Put(int id, GradeDTO grade)
        {
            return _gradeRepository.Put(id, _mapper.Map<GradeEntity>(grade));
        }

        public bool Delete(int id)
        {
            return _gradeRepository.Delete(id);

        }
    }
}
