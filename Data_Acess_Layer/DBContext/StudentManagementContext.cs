using Data_Acess_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Acess_Layer.DBContext
{
    public class StudentManagementContext : DbContext
    {
        public StudentManagementContext(DbContextOptions<StudentManagementContext> options) : base(options)
        {

        }
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<StudentAddressEntity> Addresses { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }
        public DbSet<StudentCourseEntity> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourseEntity>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });
        }

    }
}
