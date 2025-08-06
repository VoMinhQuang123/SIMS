using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Service
{
    public class Login_Service
    {
        private readonly ILogin login;
        public Login_Service(ILogin login)
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

            return user.PasswordHash.Equals(password) ? user : null;
        }
    }
}
