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

        public List<StudentEntity> Get()
        {
            return _dbContext.Students.ToList();
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
