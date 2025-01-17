﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Data_Acess_Layer.Entities
{
	public class CourseEntity
    {
        [Key]
		public int CourseId { get; set; }
		public string CourseName { get; set; }
		public string Description { get; set; }
        public ICollection<StudentCourseEntity> StudentCourses { get; set; }

    }
}

