using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Repository
{
    public class LoginRepository : ILogin
    {
        private readonly SIMSDBContext _connection;

        public LoginRepository(SIMSDBContext connection)
        {
            _connection = connection;
        }
        public async Task addAsync(User user)
        {
            await _connection.UsersDb.AddAsync(user);
        }
        public async Task<User?> GetUsersByID(int id)
        {
            return await _connection.UsersDb.FindAsync(id).AsTask();
        }
        public async Task<User?> GetUsersByUsername(string username)
        {
            return await _connection.UsersDb.FirstOrDefaultAsync(u => u.Username == username);
        }
        public async Task SaveChangeAsync()
        {
            await _connection.SaveChangesAsync();
        }
    }
}
