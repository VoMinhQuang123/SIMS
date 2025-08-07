using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_TeachingAssignment : ITeachingAssignment
    {
        private readonly SIMSDBContext _context;
        public Repository_TeachingAssignment(SIMSDBContext context)
        {
            _context = context; 
        }
        public Task AddTeachingAssignmentAsync(TeachingAssignment entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeachingAssignmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TeachingAssignment>> GetAllTeachingAssignmentsAsync()
        {
            return await _context.TeachingAssignmentsDb
                .Include(c => c.Class)
                .Include(c => c.Course)
                .Include(c => c.Teacher)
                .Include(c => c.Semester) 
              .ToListAsync();
        }

        public Task<TeachingAssignment?> GetTeachingAssignmentByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeachingAssignmentAsync(TeachingAssignment entity)
        {
            throw new NotImplementedException();
        }
    }
}
