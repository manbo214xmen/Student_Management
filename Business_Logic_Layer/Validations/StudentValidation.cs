using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Repositories;

namespace Business_Logic_Layer.Validations
{
    public class StudentValidation
    {
        private readonly GradeRepository _gradeRepository;
        private readonly StudentRepository _studentRepository;

        public StudentValidation(GradeRepository gradeRepository, StudentRepository studentRepository)
        {
            _gradeRepository = gradeRepository;
            _studentRepository = studentRepository;
        }

        public void ValidateStudent(StudentDTO student)
        {
            ValidateGrade(student.CurrentGradeId);
            ValidateEmail(student.StudentEmail);
            ValidatePhoneNumber(student.StudentPhone);
        }

        public void ValidateStudentId (int studentId)
        {
            if (!_studentRepository.Exists(studentId))
            {
                throw new ArgumentException("Invalid studentId. Student not found.!!!");
            }
        }

        private void ValidateGrade(int gradeId)
        {
            if (!_gradeRepository.Exists(gradeId))
            {
                throw new ArgumentException("Invalid gradeId. Grade not found.!!!");
            }
        }

        private void ValidateEmail(string email)
        {
            // Check if the email is in the correct format
            if (!IsValidEmail(email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            if (!_studentRepository.IsEmailUnique(email))
            {
                throw new ArgumentException("Email already exists. Please use a unique email address.");
            }
        }

        private void ValidatePhoneNumber(string phone)
        {
            if (!IsValidPhoneNumber(phone))
            {
                throw new ArgumentException("Invalid phone number format.");
            }
            if (!_studentRepository.IsPhoneNumberUnique(phone))
            {
                throw new ArgumentException("Phone number already exists. Please use a unique phone number.");
            }
        }

        //To check if the input email is the correct email format
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return Regex.IsMatch(email, emailPattern);
        }

        //To check if the input phone number contains only numeric characters
        private bool IsValidPhoneNumber(string phone)
        {
            string phonePattern = @"(84|0[3|5|7|8|9])+([0-9]{8})\b";
            return Regex.IsMatch(phone, phonePattern);
        }
    }
}
