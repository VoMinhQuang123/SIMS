using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Semester : ISemester
    {
        public Task AddSemesterAsync(Semester entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSemesterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Semester>> GetAllSemesteresAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Semester?> GetSemesterByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSemesterAsync(Semester entity)
        {
            throw new NotImplementedException();
        }
    }
}
