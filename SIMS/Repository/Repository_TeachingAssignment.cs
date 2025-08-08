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
        public async Task AddTeachingAssignmentAsync(TeachingAssignment entity)
        {
            _context.TeachingAssignmentsDb.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeachingAssignmentAsync(int id)
        {
            var assignment = await _context.TeachingAssignmentsDb.FirstOrDefaultAsync(s => s.AssignmentID == id);

            if (assignment != null)
            {
                _context.TeachingAssignmentsDb.Remove(assignment);
                await _context.SaveChangesAsync();
            }
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

        public async Task UpdateTeachingAssignmentAsync(TeachingAssignment entity)
        {
            var existingASM = await _context.TeachingAssignmentsDb.FindAsync(entity.AssignmentID);

            if (existingASM != null)
            {
                existingASM.SemesterID = entity.SemesterID;
                existingASM.ClassID = entity.ClassID;
                existingASM.TeacherID = entity.TeacherID;
                existingASM.CourseID = entity.CourseID;
                await _context.SaveChangesAsync();
            }
        }
    }
}
