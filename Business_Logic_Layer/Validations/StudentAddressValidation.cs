using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Repositories;

namespace Business_Logic_Layer.Validations
{
    public class StudentAddressValidation
    {
        private readonly StudentAddressRepository _studentAddressRepository;
        private readonly StudentRepository _studentRepository;

        public StudentAddressValidation (StudentAddressRepository studentAddressRepository, StudentRepository studentRepository)
        {
            _studentAddressRepository = studentAddressRepository;
            _studentRepository = studentRepository;
        }

        public void ValidateStudentAddress(StudentAddressDTO studentAddress)
        {
            ValidateStudent(studentAddress.StudentId);
           
        }

        private void ValidateStudent(int studentId)
        {
            if (!_studentRepository.Exists(studentId))
            {
                throw new ArgumentException("Invalid studentId. Student not found.!!!");
            }
        }
    }
}
