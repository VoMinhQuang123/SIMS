using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
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
        public async Task AddTypeAsync(Type1 entity)
        {
            _context.TypesDb.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTypeAsync(int id)
        {
            var type = await _context.TypesDb.FirstOrDefaultAsync(s => s.TypeID == id);

            if (type != null)
            {
                _context.TypesDb.Remove(type);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Type1>> GetAllTypesAsync()
        {

            return await _context.TypesDb.ToListAsync();
        }

        public Task<BDContext.Entity.Type1?> GetTypeByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTypeAsync(Type1 entity)
        {
            var existingType = await _context.TypesDb.FindAsync(entity.TypeID);

            if (existingType != null)
            {
                existingType.TypeName = entity.TypeName;
                existingType.Description = entity.Description;
                
                await _context.SaveChangesAsync();
            }
        }
    }
}
