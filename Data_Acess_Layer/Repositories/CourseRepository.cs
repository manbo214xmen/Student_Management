using System;
using Data_Acess_Layer.DBContext;
using Data_Acess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data_Acess_Layer.Repositories
{
    public class CourseRepository
	{
        private readonly StudentManagementContext _dbContext;

        public CourseRepository(StudentManagementContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool Exists(int courseId)
        {
            return _dbContext.Courses.Any(g => g.CourseId == courseId);
        }

        public bool IsCourseNameUnique(string name)
        {
            return !_dbContext.Courses.Any(g => g.CourseName == name);
        }

        //Paging and Filtering Courses
        public IEnumerable<CourseEntity> PagingAndFilteringCourses(int page, int pageSize, string filter)
        {
            //Get all courses
            IEnumerable<CourseEntity> courses = Get();
            // Apply filtering
            var filteredCourses = courses
                        .Where(s => s.CourseName.Contains(filter, StringComparison.OrdinalIgnoreCase))
                        .ToList(); // ToList to execute filtering on memory

            // Apply paging                                   
            var paginatedCourses = filteredCourses
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList(); // ToList to execute paging on memory
            return paginatedCourses;
        }
        public List<CourseEntity> Get()
        {
            return _dbContext.Courses.ToList();
        }

        public CourseEntity Get(int id)
        {
            return _dbContext.Courses.FirstOrDefault(x => x.CourseId.Equals(id));
        }

        // Get students by course id
        public List<StudentEntity> GetStudentsByCourseId(int courseId)
        {
            var students = _dbContext.Courses
                .Where(c => c.CourseId == courseId)
                .SelectMany(c => c.StudentCourses)
                .Select(sc => sc.Student)
                .ToList();

            return students;
        }

        public void Post(CourseEntity course)
        {
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();
        }

        public bool Put(int id, CourseEntity course)
        {
            var courseUpdate = _dbContext.Courses.FirstOrDefault(x => x.CourseId.Equals(id));

            if (courseUpdate == null)
            {
                return false;
            }
            course.CourseId = id;
            _dbContext.Courses.Update(course);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var course = _dbContext.Courses.FirstOrDefault(x => x.CourseId.Equals(id));
            if (course == null)
            {
                return false;
            }
            _dbContext.Courses.Remove(course);
            _dbContext.SaveChanges();
            return true;
        }
    }
}


