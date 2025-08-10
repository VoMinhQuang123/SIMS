using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Service
{
    public class Service_TeachingAssignment
    {
        // Inheriting interfaces
        private readonly ITeachingAssignment _assignment;
        private readonly SIMSDBContext _context;

        // Create constructor
        public Service_TeachingAssignment(ITeachingAssignment teachingAssignment, SIMSDBContext _context)
        {
            _assignment = teachingAssignment;
           this._context = _context;
        }

        // Get all Teaching Assignments
        public async Task<List<TeachingAssignment>> GetAllAssignmentsAsync()
        {
            return await _assignment!.GetAllTeachingAssignmentsAsync();
        }

        // Get information TeachingAssignment by ID
        public async Task<List<TeachingAssignment?>> GetTeachingAssignmentByIDAsync(int id)
        {
            return await _assignment.GetTeachingAssignmentByIDAsync(id);
        }

        // Add new TeachingAssignment 
        public async Task AddTeachingAssignmentAsync(TeachingAssignment entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            _context.TeachingAssignmentsDb.Add(entity);
            await _assignment.AddTeachingAssignmentAsync(entity);
        }

        // Update information TeachingAssignment
        public async Task UpdateTeachingAssignmentAsync(TeachingAssignment entity)
        {
            await _assignment.UpdateTeachingAssignmentAsync(entity);
        }

        // Delete TeachingAssignment by ID
        public async Task DeleteTeachingAssignmentAsync(int id)
        {
            await _assignment.DeleteTeachingAssignmentAsync(id);
        }
    }
}
