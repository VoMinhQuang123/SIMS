using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface ILogin
    {
        Task<User?> GetUsersByID(int id);
        Task<User?> GetUsersByUsername(string Username);
        Task addAsync(User user);
        Task SaveChangeAsync();
    }
}
