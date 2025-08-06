using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_User : IUser
    {
        public Task AddUserAsync(User entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteUserAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
