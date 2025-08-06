using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Admin : IAdmin
    {
        public Task AddAdminAsync(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAdminAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Admin?> GetAdminByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Admin>> GetAllAdminsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAdminAsync(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
