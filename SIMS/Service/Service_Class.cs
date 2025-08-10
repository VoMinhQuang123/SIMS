using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;
using System;

namespace SIMS.Service
{
    public class Service_Class
    {
        // Inheriting interfaces
        private readonly IClass _class;
        private readonly SIMSDBContext sIMSDBContext;

        // Create constructor
        public Service_Class(IClass @class, SIMSDBContext sIMSDBContext)
        {
            _class = @class;
            this.sIMSDBContext = sIMSDBContext;
        }

        // Get all Classes
        public async Task<List<Class>> GetAllClassesAsync()
        {
            return await _class!.GetAllClassesAsync();
        }

        // Get information Class by ID
        public async Task<List<Class>> GetClassByIDTypeAsync(int id)
        {
            var result = await sIMSDBContext.ClassesDb.Where(c => c.TypeID == id).ToListAsync();
            return result;
        }

        // Add new Class 
        public async Task AddClassAsync(Class entity)
        {
            entity.CreatedAt = DateTime.Now;
            entity.UpdatedAt = DateTime.Now;
            await _class.AddClassAsync(entity);
        }

        // Update information Class
        public async Task UpdateClassAsync(Class entity)
        {
            await _class.UpdateClassAsync(entity);
        }

        // Delete Class by ID
        public async Task DeleteClassAsync(int id)
        {
            await _class.DeleteClassAsync(id);
        }
    }
}
