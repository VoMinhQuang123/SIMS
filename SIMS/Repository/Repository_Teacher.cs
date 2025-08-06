using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Teacher : ITeacher
    {
        public Task AddTeacherAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTeacherAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetAllTeacheresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Teacher?> GetTeacherByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTeacherAsync(Teacher entity)
        {
            throw new NotImplementedException();
        }
    }
}
