using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Repositories;

namespace Business_Logic_Layer.Validations
{
    public class GradeValidation
    {
        private readonly GradeRepository _gradeRepository;

        public GradeValidation(GradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository; 
        }

        public void ValidateGradeId(int id)
        {
            if (!_gradeRepository.Exists(id))
            {
                throw new ArgumentException("Invalid Grade Id. !!!");
            }
        }

        public void ValidateGrade(GradeDTO grade)
        {
            if(!_gradeRepository.IsGradeNameUnique(grade.GradeName))
            {
                throw new ArgumentException("Grade Name Already Exists.!!!");
            }
        }
    }
}
