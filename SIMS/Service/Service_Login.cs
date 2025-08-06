using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Service
{
    public class Service_Login
    {
        // Inheriting interfaces
        private readonly ILogin login;
        public Service_Login(ILogin login)
        {
            this.login = login;
        }
        public async Task<User?> LoginUserAsync(string Username, string password)
        {
            var user = await login.GetUsersByUsername(Username);
            if (user == null)
            {
                return null;
            }

            return user.PasswordHash!.Equals(password) ? user : null;
        }
    }
}
