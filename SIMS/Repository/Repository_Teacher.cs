using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Teacher : ITeacher
    {
        private readonly SIMSDBContext _context;
        public Repository_Teacher(SIMSDBContext context)
        {
            _context = context;
        }
        public Task AddTeacherAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeacherAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Teacher>> GetAllTeacheresAsync()
        {
            return await _context.TeachersDb
              .Include(c => c.Type)
              .ToListAsync();
        }

        public Task<Teacher?> GetTeacherByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeacherAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
