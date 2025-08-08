using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Student : IStudent
    {
        private readonly SIMSDBContext _context;
        public Repository_Student(SIMSDBContext context)
        {
            _context = context;
        }
        public async Task AddStudentAsync(Student entity)
        {
            _context.StudentsDb.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.StudentsDb.FirstOrDefaultAsync(s => s.StudentID == id);

            if (student != null)
            {
                _context.StudentsDb.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.StudentsDb
               .Include(c => c.Class)
               .Include(c => c.Type)
               .ToListAsync();
        }

        public Task<Student?> GetStudentByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateStudentAsync(Student entity)
        {
            var existingStudent = await _context.StudentsDb.FindAsync(entity.StudentID);

            if (existingStudent != null)
            {
                existingStudent.Name = entity.Name;
                existingStudent.DoB = entity.DoB;
                existingStudent.Address = entity.Address;
                existingStudent.TypeID = entity.TypeID;
                existingStudent.ClassID = entity.ClassID;
                await _context.SaveChangesAsync();
            }
        }
    }
}
