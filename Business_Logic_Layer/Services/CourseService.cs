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
    public class CourseService
    {
        private readonly CourseRepository _courseRepository;
        private readonly CourseValidation _courseValidation;
        private readonly IMapper _mapper;

        public CourseService(CourseRepository courseRepository, CourseValidation courseValidation ,IMapper mapper)
        {
            this._courseRepository = courseRepository;
            this._courseValidation = courseValidation;
            this._mapper = mapper;
        }

        public List<CourseDTO> Get()
        {


            return _mapper.Map<List<CourseDTO>>(_courseRepository.Get());
        }

        //public List<StudentDTO> GetFilterStudent(string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{


        //    return mapper.Map<List<StudentDTO>>(studentRepository.GetFilterStudent(name, gradeId, sortType, sortField, pageNumber, pageSize));
        //}

        //Paging and Filtering Courses
        public IEnumerable<CourseDTO> PagingAndFilteringCourses(int page, int pageSize, string filter)
        {
            var courses = _courseRepository.PagingAndFilteringCourses(page, pageSize, filter);
            return _mapper.Map<List<CourseDTO>>(courses);
        }

        public CourseDTO Get(int id)
        {


            return _mapper.Map<CourseDTO>(_courseRepository.Get(id));
        }

        public void Post(CourseDTO course)
        {
            _courseValidation.ValidateCourse(course);
            _courseRepository.Post(_mapper.Map<CourseEntity>(course));
        }
        public bool Put(int id, CourseDTO course)
        {
            _courseValidation.ValidateCourse(course);
            return _courseRepository.Put(id, _mapper.Map<CourseEntity>(course));
        }
        public bool Delete(int id)
        {
            return _courseRepository.Delete(id);

        }
    }
}
