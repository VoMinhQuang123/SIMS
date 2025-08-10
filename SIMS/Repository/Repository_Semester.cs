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
        public async Task AddSemesterAsync(Semester entity)
        {
            _context.SemestersDb.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSemesterAsync(int id)
        {
            var semester = await _context.SemestersDb.FirstOrDefaultAsync(s => s.SemesterID == id);

            if (semester != null)
            {
                _context.SemestersDb.Remove(semester);
                await _context.SaveChangesAsync();
            }
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

        public async Task UpdateSemesterAsync(Semester entity)
        {
            var existingSemester = await _context.SemestersDb.FindAsync(entity.SemesterID);

            if (existingSemester != null)
            {
                existingSemester.Name = entity.Name;
                existingSemester.Description = entity.Description;
                existingSemester.StartDate = entity.StartDate;
                existingSemester.EndDate = entity.EndDate;
                existingSemester.TypeID = entity.TypeID;
                await _context.SaveChangesAsync();
            }
        }
    }
}
