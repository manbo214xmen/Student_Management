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
        private readonly StudentManagementContext _dbContext;

        public GradeRepository(StudentManagementContext dbContext)
        {
            this._dbContext = dbContext;
        }

        //To check if GradeId exists
        public bool Exists(int gradeId)
        {
            return _dbContext.Grades.Any(g => g.GradeId == gradeId);
        }

        public List<GradeEntity> Get()
        {
            return _dbContext.Grades.ToList();
        }

        public GradeEntity Get(int id)
        {
            return _dbContext.Grades.FirstOrDefault(x => x.GradeId.Equals(id));
        }

        public void Post(GradeEntity grade)
        {
            _dbContext.Grades.Add(grade);
            _dbContext.SaveChanges();
        }

        public bool Put(int id, GradeEntity grade)
        {
            var courseUpdate = _dbContext.Grades.FirstOrDefault(x => x.GradeId.Equals(id));

            if (courseUpdate == null)
            {
                return false;
            }

            _dbContext.Grades.Update(grade);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var grade = _dbContext.Grades.FirstOrDefault(x => x.GradeId.Equals(id));
            if (grade == null)
            {
                return false;
            }
            _dbContext.Grades.Remove(grade);
            _dbContext.SaveChanges();
            return true;
        }
    }
}


