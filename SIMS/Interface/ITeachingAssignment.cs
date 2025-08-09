using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface ITeachingAssignment
    {
        Task<List<TeachingAssignment>> GetAllTeachingAssignmentsAsync();
        Task<List<TeachingAssignment?>> GetTeachingAssignmentByIDAsync(int id);
        Task AddTeachingAssignmentAsync(TeachingAssignment entity);
        Task UpdateTeachingAssignmentAsync(TeachingAssignment entity);
        Task DeleteTeachingAssignmentAsync(int id);
    }
}
