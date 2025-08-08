using Microsoft.EntityFrameworkCore;
using SIMS.BDContext.Entity;
namespace SIMS.BDContext
{
    public class SIMSDBContext : DbContext
    {
        public SIMSDBContext()
        {
        }

        public SIMSDBContext(DbContextOptions<SIMSDBContext> options) : base(options) { }
        public DbSet<User> UsersDb { get; set; }
        public DbSet<Admin> AdminsDb { get; set; }
        public DbSet<Entity.Type1> TypesDb { get; set; }
        public DbSet<Class> ClassesDb { get; set; }
        public DbSet<Student> StudentsDb { get; set; } = null!;
        public DbSet<Teacher> TeachersDb { get; set; }
        public DbSet<Course> CoursesDb { get; set; }
        public DbSet<Semester> SemestersDb { get; set; }
        public DbSet<TeachingAssignment> TeachingAssignmentsDb { get; set; }
       
            
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Users
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.UserID);
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("Student");

            // Admin
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Admin>().HasKey(a => a.AdminID);
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(a => a.UserID)
                .OnDelete(DeleteBehavior.Cascade);
                //.HasForeignKey<Admin>(a => a.UserID); 
            // Type
            modelBuilder.Entity<Entity.Type1>().ToTable("Type");
            modelBuilder.Entity<Entity.Type1>().HasKey(t => t.TypeID);

            // Class
            modelBuilder.Entity<Class>().ToTable("Class");
            modelBuilder.Entity<Class>().HasKey(c => c.ClassID);
            modelBuilder.Entity<Class>().Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<Class>().Property(c => c.UpdatedAt).HasDefaultValueSql("GETDATE()");



            // Student
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Student>().HasKey(s => s.StudentID);
            modelBuilder.Entity<Student>()
                .HasOne(s => s.User)
                .WithOne(u => u.Student)
                .HasForeignKey<Student>(s => s.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // Teacher
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Teacher>().HasKey(t => t.TeacherID);
            modelBuilder.Entity<Teacher>()
                .HasOne(t => t.User)
                .WithOne(u => u.Teacher)
                .HasForeignKey<Teacher>(t => t.UserID)
                .OnDelete(DeleteBehavior.Cascade);

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