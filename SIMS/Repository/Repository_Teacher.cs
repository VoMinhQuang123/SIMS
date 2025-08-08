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
        public async Task AddTeacherAsync(Teacher entity)
        {
            _context.TeachersDb.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(int id)
        {
            var teacher = await _context.TeachersDb.FirstOrDefaultAsync(s => s.TeacherID == id);

            if (teacher != null)
            {
                _context.TeachersDb.Remove(teacher);
                await _context.SaveChangesAsync();
            }
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

        public async Task UpdateTeacherAsync(Teacher entity)
        {
            var existingTeacher = await _context.TeachersDb.FindAsync(entity.TeacherID);

            if (existingTeacher != null)
            {
                existingTeacher.Name = entity.Name;
                existingTeacher.Email = entity.Email; 
                existingTeacher.TypeID = entity.TypeID;
                await _context.SaveChangesAsync();
            }
        }
    }
}
