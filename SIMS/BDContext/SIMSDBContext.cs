using Microsoft.EntityFrameworkCore;

using SIMS.BDContext.Entity;
using SIMS.Model.User;
using Student = SIMS.BDContext.Entity.Student;
namespace SIMS.BDContext
{
    internal class SIMSDBContext : DbContext
    {
         public SIMSDBContext(DbContextOptions<SIMSDBContext> options) : base(options) { }
       
        public DbSet<Course> CoursesDb { get; set; } 
        public DbSet<Student> StudentsDb { get; set; }
        public DbSet<Teacher> TeachersDb { get; set; }
        


    }
}