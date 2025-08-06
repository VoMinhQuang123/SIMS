using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;


namespace SIMS.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SIMSDBContext _context ;

        public StudentRepository(SIMSDBContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            
            return await _context.StudentsDb
                .Include(s => s.User)
                .Include(s => s.Class)
                .Include(s => s.Type)
                .ToListAsync(); // <- nhớ await
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.StudentsDb
                .Include(s => s.User)
                .Include(s => s.Class)
                .Include(s => s.Type)
                .FirstOrDefaultAsync(s => s.StudentID == id);
        }


        public async Task CreateStudentAsync(Student student)
        {
            student.CreatedAt = DateTime.UtcNow;
            _context.StudentsDb.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {
            var existingStudent = await _context.StudentsDb.FindAsync(student.StudentID);
            if (existingStudent == null) return false;

            existingStudent.Name = student.Name;
            existingStudent.DoB = student.DoB;
            existingStudent.Email = student.Email;
            existingStudent.Address = student.Address;
            existingStudent.TypeID = student.TypeID;
            existingStudent.ClassID = student.ClassID;
            existingStudent.UserID = student.UserID;
            existingStudent.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            var student = await _context.StudentsDb.FindAsync(studentId);
            if (student == null) return false;

            _context.StudentsDb.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }

        



    }
}

