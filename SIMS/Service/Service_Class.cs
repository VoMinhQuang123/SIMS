using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Service
{
    public class Service_Class
    {
        // Inheriting interfaces
        private readonly IClass _class;

        // Create constructor
        public Service_Class(IClass @class)
        {
            _class = @class;
        }

        // Get all Classes
        public async Task<List<Class>> GetAllClassesAsync()
        {
            return await _class!.GetAllClassesAsync();
        }

        // Get information Class by ID
        public async Task<Class?> GetClassByIDAsync(int id)
        {
            return await _class.GetClassByIDAsync(id);
        }

        // Add new Class 
        public async Task AddClassAsync(Class entity)
        {
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
