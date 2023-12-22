using Data_Acess_Layer.DBContext;
using Data_Acess_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acess_Layer.Repositories
{
    public class StudentRepository
    {

        private readonly StudentManagementContext _dbContext;

        public StudentRepository(StudentManagementContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public bool IsPhoneNumberUnique(string phone)
        {
            // Implement logic to check if the phone number is unique in your database
            // Return true if the phone number is unique, false otherwise
            return !_dbContext.Students.Any(s => s.StudentPhone == phone);
        }

        //To check if Email is unique
        public bool IsEmailUnique(string email)
        {
            // Implement logic to check if the email is unique in your database
            // Return true if the email is unique, false otherwise
            return !_dbContext.Students.Any(s => s.StudentEmail == email);
        }

        //To check if StudentId exists
        public bool Exists(int studentId)
        {
            return _dbContext.Students.Any(g => g.StudentId == studentId);
        }

        public IEnumerable<CourseEntity> GetEnrolledCoursesByStudentId(int studentId)
        {
            //Eager loading:
            // Implement logic to fetch enrolled courses for a student
            //var student = _dbContext.Students
            //    .Include(s => s.StudentCourses)
            //    .ThenInclude(sc => sc.Course)
            //    .FirstOrDefault(s => s.StudentId == studentId);

            //return student?.StudentCourses?.Select(sc => sc.Course);

            //Lazy loading: advantageous when loading massive amount of students from database
            var student = _dbContext.Students
                .Where(s => s.StudentId == studentId)
                .SelectMany(s => s.StudentCourses)
                .Select(sc => sc.Course)
                .ToList();

            return student;
        }
        public List<StudentEntity> Get()
        {
            return _dbContext.Students.ToList();
        }

        //Paging and Filtering Students
        public IEnumerable<StudentEntity> PagingAndFilteringStudents(int page, int pageSize, string filter)
        {
            //Get all students
            IEnumerable<StudentEntity> students = Get();
            // Apply filtering
            var filteredStudents = students
                        .Where(s => s.StudentName.Contains(filter, StringComparison.OrdinalIgnoreCase))
                        .ToList(); // ToList to execute filtering on memory

            // Apply paging                                   
            var paginatedStudents = filteredStudents
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList(); // ToList to execute paging on memory
            return paginatedStudents;
        }


        //public List<StudentEntity> GetFilterStudent(string? name, string? gradeId, string? sortType, string? sortField, int pageNumber, int pageSize)
        //{

        //    IEnumerable<StudentEntity> students = Get();
        //    if (name != null)
        //    {
        //        students = students.Where(x => x.StudentName.Contains(name));
        //    }
        //    if (gradeId != null)
        //    {
        //        students = students.Where(x => x.CurrentGradeId.Contains(gradeId));
        //    }

        //    if (sortType != null)
        //    {
        //        if (sortField != null)
        //        {
        //            char[] text = sortField.ToCharArray();
        //            text[0] = char.ToUpper(text[0]);
        //            sortField = new String(text);
        //        }
        //        students = sortType == "desc"
        //            ? students.OrderByDescending(s => !String.IsNullOrEmpty(sortField) ? s.GetType().GetProperty(sortField)?.GetValue(s, null) : s.StudentName)
        //            : students.OrderBy(s => !String.IsNullOrEmpty(sortField) ? s.GetType().GetProperty(sortField)?.GetValue(s, null) : s.StudentName);
        //    }
        //    if (pageNumber >= 1 && pageSize >= 1)
        //    {

        //        students = PaginatedList<StudentEntity>.Create(students, pageSize, pageNumber);
        //    }
        //    return students.ToList();
        //}
        public StudentEntity Get(int id)
        {
            return _dbContext.Students.FirstOrDefault(x => x.StudentId.Equals(id));
        }

        public StudentEntity GetStudentWithDetailsById(int studentId)
        {
            return _dbContext.Students
                .Include(s => s.CurrentGrade)
                .Include(s => s.Address)
                .FirstOrDefault(s => s.StudentId == studentId);
        }

        public void AssignCourse(int studentId, int courseId)
        {
            var studentCourse = new StudentCourseEntity
            {
                StudentId = studentId,
                CourseId = courseId
            };

            _dbContext.StudentCourses.Add(studentCourse);
            _dbContext.SaveChanges();
        }

        public void Post(StudentEntity student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public bool Put(int id, StudentEntity student)
        {
            var studentUpdate = _dbContext.Students.FirstOrDefault(x => x.StudentId.Equals(id));

            if (studentUpdate == null)
            {
                return false;
            }
            student.StudentId = id;
            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var student = _dbContext.Students.FirstOrDefault(x => x.StudentId.Equals(id));
            if (student == null)
            {
                return false;
            }
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
