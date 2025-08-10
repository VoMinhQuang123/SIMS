using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;
using Microsoft.EntityFrameworkCore;

namespace SIMS.Repository
{
    public class Repository_User : IUser
    {
        private readonly SIMSDBContext _context;

        public Repository_User(SIMSDBContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User entity)
        {
            await _context.UsersDb.AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.UsersDb.FindAsync(id);
            if (user != null)
            {
                _context.UsersDb.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.UsersDb.ToListAsync();
        }

        public async Task<User?> GetUserByIDAsync(int id)
        {
            return await _context.UsersDb.FindAsync(id);
        }

        public async Task UpdateUserAsync(User entity)
        {
            _context.UsersDb.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
