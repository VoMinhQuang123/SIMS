using Microsoft.EntityFrameworkCore;
using SIMS.BDContext.Entity;
namespace SIMS.BDContext
{
    internal class SIMSDBContext : DbContext
    {
        public SIMSDBContext(DbContextOptions<SIMSDBContext> options) : base(options) { }
        public DbSet<Admin> AdminsDb { get; set; }
        public DbSet<Entity.Type> TypesDb { get; set; }
        public DbSet<Class> ClassesDb { get; set; }
        public DbSet<Entity.Student> StudentsDb { get; set; }
        public DbSet<Teacher> TeachersDb { get; set; }
        public DbSet<Course> CoursesDb { get; set; }
        public DbSet<Semester> SemestersDb { get; set; }
        public DbSet<TeachingAssignment> TeachingAssignmentsDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Admin
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Entity.Admin>().HasKey(a => a.AdminID);

            // Type
            modelBuilder.Entity<Entity.Type>().ToTable("Type");
            modelBuilder.Entity<Entity.Type>().HasKey(t => t.TypeID);

            // Class
            modelBuilder.Entity<Class>().ToTable("Class");
            modelBuilder.Entity<Class>().HasKey(c => c.ClassID);
            modelBuilder.Entity<Class>().Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Class>().Property(c => c.UpdatedAt).HasDefaultValueSql("GETDATE()");

            // Student
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Student>().HasKey(s => s.StudentID);

            // Teacher
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Teacher>().HasKey(t => t.TeacherID);

            // Course
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Course>().HasKey(c => c.CourseID);
            modelBuilder.Entity<Course>().Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Course>().Property(c => c.UpdatedAt).HasDefaultValueSql("GETDATE()");

            // Semester
            modelBuilder.Entity<Semester>().ToTable("Semester");
            modelBuilder.Entity<Semester>().HasKey(s => s.SemesterID);
            modelBuilder.Entity<Semester>().Property(s => s.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Semester>().Property(s => s.UpdatedAt).HasDefaultValueSql("GETDATE()");

            // TeachingAssignment
            modelBuilder.Entity<TeachingAssignment>().ToTable("TeachingAssignment");
            modelBuilder.Entity<TeachingAssignment>().HasKey(t => t.AssignmentID);
            modelBuilder.Entity<TeachingAssignment>().Property(t => t.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TeachingAssignment>().Property(t => t.UpdatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}