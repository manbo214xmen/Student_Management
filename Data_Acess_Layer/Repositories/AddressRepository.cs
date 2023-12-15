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
    public class AddressRepository
	{
        private readonly StudentManagementContext dbContext;

        public AddressRepository(StudentManagementContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<StudentAddressEntity> Get()
        {
            return dbContext.Addresses.ToList();
        }

        public StudentAddressEntity Get(int id)
        {
            return dbContext.Addresses.FirstOrDefault(x => x.StudentAdressId.Equals(id));
        }

        public void Post(StudentAddressEntity grade)
        {
            dbContext.Addresses.Add(grade);
            dbContext.SaveChanges();
        }

        public bool Put(int id, StudentAddressEntity grade)
        {
            var addressUpdate = dbContext.Addresses.FirstOrDefault(x => x.StudentAdressId.Equals(id));

            if (addressUpdate == null)
            {
                return false;
            }

            dbContext.Addresses.Update(addressUpdate);
            dbContext.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var address = dbContext.Addresses.FirstOrDefault(x => x.StudentAdressId.Equals(id));
            if (address == null)
            {
                return false;
            }
            dbContext.Addresses.Remove(address);
            dbContext.SaveChanges();
            return true;
        }
    }
}

