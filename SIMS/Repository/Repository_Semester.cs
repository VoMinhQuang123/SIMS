using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Semester : ISemester
    {
        private readonly SIMSDBContext _context;
        public Repository_Semester(SIMSDBContext context)
        {
            _context = context;
        }
        public Task AddSemesterAsync(Semester entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSemesterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Semester>> GetAllSemesteresAsync()
        {
            return await _context.SemestersDb
             .Include(c => c.Type)
             .ToListAsync();
        }

        public Task<Semester?> GetSemesterByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSemesterAsync(Semester entity)
        {
            throw new NotImplementedException();
        }
    }
}
