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
    public class StudentAddressRepository
    {
        private readonly StudentManagementContext _dbContext;

        public StudentAddressRepository(StudentManagementContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public List<StudentAddressEntity> Get()
        {
            return _dbContext.Addresses.ToList();
        }

        public StudentAddressEntity Get(int id)
        {
            return _dbContext.Addresses.FirstOrDefault(x => x.StudentAddressId.Equals(id));
        }

        public void Post(StudentAddressEntity studentAddressEntity)
        {
            _dbContext.Addresses.Add(studentAddressEntity);
            _dbContext.SaveChanges();
        }

        public bool Put(int id, StudentAddressEntity studentAddressEntity)
        {
            var addressUpdate = _dbContext.Addresses.FirstOrDefault(x => x.StudentAddressId.Equals(id));

            if (addressUpdate == null)
            {
                return false;
            }

            _dbContext.Addresses.Update(studentAddressEntity);
            _dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var address = _dbContext.Addresses.FirstOrDefault(x => x.StudentAddressId.Equals(id));
            if (address == null)
            {
                return false;
            }
            _dbContext.Addresses.Remove(address);
            _dbContext.SaveChanges();
            return true;
        }
    }
}


