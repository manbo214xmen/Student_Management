using System;
using Data_Acess_Layer.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data_Acess_Layer
{   
    //This class is for MacOS, which does not recognize DBContext in Program.cs in Presentation Layer
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StudentManagementContext>
    {
        public StudentManagementContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StudentManagementContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=StudentManagementContext;User Id=sa;Password=Hung@123456789;Trusted_Connection=false;TrustServerCertificate=True;");

            return new StudentManagementContext(optionsBuilder.Options);
        }
    }

}

