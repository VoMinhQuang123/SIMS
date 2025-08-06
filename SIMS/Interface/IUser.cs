using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface IUser
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIDAsync(int id);
        Task AddUserAsync(User entity);
        Task UpdateUserAsync(User entity);
        Task DeleteUserAsync(int id);
    }
}
