using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Service
{
    public class Service_User
    {
        private readonly IUser _user;

        public Service_User(IUser user)
        {
            _user = user;
        }
        public async Task<int> AddUserAsync(User entity)
        {
            await _user.AddUserAsync(entity);
            return entity.UserID;
        }
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _user.GetAllUsersAsync();
        }

        public async Task<User?> GetUserByIDAsync(int id)
        {
            return await _user.GetUserByIDAsync(id);
        }

        public async Task UpdateUserAsync(User entity)
        {
            await _user.UpdateUserAsync(entity);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _user.DeleteUserAsync(id);
        }
    }
}
