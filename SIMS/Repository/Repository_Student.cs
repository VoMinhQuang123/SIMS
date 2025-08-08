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

        public Task DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _context.StudentsDb
               .Include(c => c.Type)
               .ToListAsync();
        }

        public Task<Student?> GetStudentByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
