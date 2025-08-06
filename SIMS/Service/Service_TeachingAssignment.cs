using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Service
{
    public class Service_TeachingAssignment
    {
        // Inheriting interfaces
        private readonly ITeachingAssignment _assignment;

        // Create constructor
        public Service_TeachingAssignment(ITeachingAssignment teachingAssignment)
        {
            _assignment = teachingAssignment;
        }

        // Get all Teaching Assignments
        public async Task<List<TeachingAssignment>> GetAllAssignmentsAsync()
        {
            return await _assignment!.GetAllTeachingAssignmentsAsync();
        }

        // Get information TeachingAssignment by ID
        public async Task<TeachingAssignment?> GetTeachingAssignmentByIDAsync(int id)
        {
            return await _assignment.GetTeachingAssignmentByIDAsync(id);
        }

        // Add new TeachingAssignment 
        public async Task AddTeachingAssignmentAsync(TeachingAssignment entity)
        {
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
