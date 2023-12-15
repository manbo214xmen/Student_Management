using System;
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

        private readonly StudentManagementContext dbContext;

        public CourseRepository(StudentManagementContext dbContext)
		{
            this.dbContext = dbContext;
        }

        
        public List<CourseEntity> Get()
        {
            return dbContext.Courses.ToList();
        }
        
        public CourseEntity Get(int id)
        {
            return dbContext.Courses.FirstOrDefault(x => x.CourseId.Equals(id));
        }

        public void Post(CourseEntity course)
        {
            dbContext.Courses.Add(course);
            dbContext.SaveChanges();
        }

        public bool Put(int id, CourseEntity course)
        {
            var courseUpdate = dbContext.Courses.FirstOrDefault(x => x.CourseId.Equals(id));

            if (courseUpdate == null)
            {
                return false;
            }

            dbContext.Courses.Update(course);
            dbContext.SaveChanges();
            return true;
        }
        public bool Delete(int id)
        {
            var course = dbContext.Courses.FirstOrDefault(x => x.CourseId.Equals(id));
            if (course == null)
            {
                return false;
            }
            dbContext.Courses.Remove(course);
            dbContext.SaveChanges();
            return true;
        }
    }
}

