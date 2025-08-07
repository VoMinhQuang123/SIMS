using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Class : IClass
    {
        private readonly SIMSDBContext _context;

        public Repository_Class(SIMSDBContext context)
        {
            _context = context;
        }

        public Task AddClassAsync(Class entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteClassAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Class>> GetAllClassesAsync()
        {
            return await _context.ClassesDb
               .Include(c => c.Type)
               .ToListAsync();
        }

        public Task<Class?> GetClassByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateClassAsync(Class entity)
        {
            throw new NotImplementedException();
        }
    }
}
