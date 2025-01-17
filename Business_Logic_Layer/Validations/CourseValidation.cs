﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Repositories;

namespace Business_Logic_Layer.Validations
{
    public class CourseValidation
    {
        public readonly CourseRepository _courseRepository;

        public CourseValidation(CourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void ValidateCourseName(CourseDTO course)
        {
             if(!_courseRepository.IsCourseNameUnique(course.CourseName))
            {
                throw new ArgumentException("Course Name Already Exists. !!!");
            }
        }

        public void ValidateCourseId (int courseId)
        {
            if (!_courseRepository.Exists(courseId))
            {
                throw new ArgumentException("Invalid courseId. Course not found.!!!");
            }
        }
    }
}
