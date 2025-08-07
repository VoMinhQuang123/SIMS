using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Type : IType
    {
        private readonly SIMSDBContext _context;
        public Repository_Type(SIMSDBContext context)
        {
            _context = context;
        }
        public Task AddTypeAsync(BDContext.Entity.Type entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BDContext.Entity.Type>> GetAllTypesAsync()
        {
            return await _context.TypesDb
              .ToListAsync();
        }

        public Task<BDContext.Entity.Type?> GetTypeByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTypeAsync(BDContext.Entity.Type entity)
        {
            throw new NotImplementedException();
        }
    }
}
