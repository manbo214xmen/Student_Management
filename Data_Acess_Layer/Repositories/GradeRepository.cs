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
    public class GradeRepository
	{
        private readonly StudentManagementContext dbContext;

        public GradeRepository(StudentManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<GradeEntity> Get()
        {
            return dbContext.Grades.ToList();
        }

        public GradeEntity Get(int id)
        {
            return dbContext.Grades.FirstOrDefault(x => x.GradeId.Equals(id));
        }

        public void Post(GradeEntity grade)
        {
            dbContext.Grades.Add(grade);
            dbContext.SaveChanges();
        }

        public bool Put(int id, GradeEntity grade)
        {
            var courseUpdate = dbContext.Grades.FirstOrDefault(x => x.GradeId.Equals(id));

            if (courseUpdate == null)
            {
                return false;
            }

            dbContext.Grades.Update(grade);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var grade = dbContext.Grades.FirstOrDefault(x => x.GradeId.Equals(id));
            if (grade == null)
            {
                return false;
            }
            dbContext.Grades.Remove(grade);
            dbContext.SaveChanges();
            return true;
        }
    }
}

