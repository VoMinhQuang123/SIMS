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

        public async Task AddClassAsync(Class entity)
        {

            _context.ClassesDb.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClassAsync(int id)
        {
            var classes = await _context.ClassesDb.FirstOrDefaultAsync(s => s.ClassID == id);

            if (classes != null)
            {
                _context.ClassesDb.Remove(classes);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Class>> GetAllClassesAsync()
        {
            return await _context.ClassesDb
               .Include(c => c.Type)
               .ToListAsync();
        }

        public Task<Class?> GetClassByIDTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateClassAsync(Class entity)
        {
            var existingClass = await _context.ClassesDb.FindAsync(entity.ClassID);

            if (existingClass != null)
            {
                existingClass.ClassName = entity.ClassName;
                existingClass.Description = entity.Description;
                existingClass.TypeID = entity.TypeID;    
                await _context.SaveChangesAsync();
            }
        }
    }
}
