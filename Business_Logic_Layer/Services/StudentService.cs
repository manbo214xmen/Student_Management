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
        private readonly CourseValidation  _courseValidation;
        private readonly IMapper _mapper;
        public StudentService(StudentRepository studentRepository, IMapper mapper, 
                                StudentValidation studentValidation, CourseValidation courseValidation)
        {
            this._studentRepository = studentRepository;
            this._studentValidation = studentValidation;
            this._courseValidation = courseValidation;
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

        public IEnumerable<StudentDTO> PagingAndFilteringStudents(int page, int pageSize, string filter)
        {
            var students = _studentRepository.PagingAndFilteringStudents(page, pageSize, filter);
            return _mapper.Map<List<StudentDTO>>(students);
        }

        public StudentDetailDTO GetStudentWithDetailsById(int studentId)
        {
            var studentWithDetails = _studentRepository.GetStudentWithDetailsById(studentId);
            return _mapper.Map<StudentDetailDTO>(studentWithDetails);
        }

        public IEnumerable<CourseDTO> GetEnrolledCoursesByStudentId(int studentId)
        {
            var enrolledCourses = _studentRepository.GetEnrolledCoursesByStudentId(studentId);
            return _mapper.Map<IEnumerable<CourseDTO>>(enrolledCourses);
        }

        public void AssignCourse(int studentId, int courseId)
        {
            _studentValidation.ValidateStudentId(studentId);
            _courseValidation.ValidateCourseId(courseId);
            _studentRepository.AssignCourse(studentId, courseId);
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
