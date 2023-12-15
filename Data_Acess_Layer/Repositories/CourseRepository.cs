﻿using System;
using Data_Acess_Layer.DBContext;
using Data_Acess_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acess_Layer.Repositories
{
    public class CourseRepository
	{
        private readonly StudentManagementContext _dbContext;

        public CourseRepository(StudentManagementContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public List<CourseEntity> Get()
        {
            return _dbContext.Courses.ToList();
        }

        public CourseEntity Get(int id)
        {
            return _dbContext.Courses.FirstOrDefault(x => x.CourseId.Equals(id));
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


