using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Service
{
    public class Service_User
    {
        // Inheriting interfaces
        private readonly IUser _user;

        // Create constructor
        public Service_User(IUser user)
        {
            _user = user;
        }

        // Get all Users
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _user!.GetAllUsersAsync();
        }

        // Get information User by ID
        public async Task<User?> GetUserByIDAsync(int id)
        {
            return await _user.GetUserByIDAsync(id);
        }

        // Add new User
        public async Task AddUserAsync(User entity)
        {
            await _user.AddUserAsync(entity);
        }

        // Update information User
        public async Task UpdateUserAsync(User entity)
        {
            await _user.UpdateUserAsync(entity);
        }

        // Delete User by ID
        public async Task DeleteUserAsync(int id)
        {
            await _user.DeleteUserAsync(id);
        }
    }
}
