using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_TeachingAssignment : ITeachingAssignment
    {
        public Task AddTeachingAssignmentAsync(TeachingAssignment entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeachingAssignmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TeachingAssignment>> GetAllTeachingAssignmentsAsync()
        {
            throw new NotImplementedException();
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
