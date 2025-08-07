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
        public Task AddStudentAsync(Student entity)
        {
            throw new NotImplementedException();
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
