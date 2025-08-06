using SIMS.BDContext.Entity;
using SIMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.Service
{
    public class Service_Admin
    {
        // Inheriting interfaces
        private readonly IAdmin _admin;

        // Create constructor
        public Service_Admin(IAdmin admin)
        {
            _admin = admin;
        }

        // Get all Admins
        public async Task<List<Admin>> GetAllAdminsAsync()
        {
            return await _admin!.GetAllAdminsAsync();
        }

        // Get information admin by ID
        public async Task<Admin?> GetAdminByIDAsync(int id)
        {
            return await _admin.GetAdminByIDAsync(id);
        }

        // Add new admin 
        public async Task AddAdminAsync(Admin entity)
        {
            await _admin.AddAdminAsync(entity);
        }

        // Update information admin
        public async Task UpdateAdminAsync(Admin entity)
        {
            await _admin.UpdateAdminAsync(entity);
        }

        // Delete admin by ID
        public async Task DeleteAdminAsync(int id)
        {
            await _admin.DeleteAdminAsync(id);
        }
    }
}
