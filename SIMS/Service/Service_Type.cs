using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Service
{
    public class Service_Type
    {
        // Inheriting interfaces
        private readonly IType _type;

        // Create constructor
        public Service_Type(IType type)
        {
            _type = type;
        }

        // Get all Types
        public async Task<List<BDContext.Entity.Type1>> GetAllTypesAsync()
        {
            return await _type!.GetAllTypesAsync();
        }

        // Get information Type by ID
        public async Task<BDContext.Entity.Type1?> GetTypeByIDAsync(int id)
        {
            return await _type.GetTypeByIDAsync(id);
        }

        // Add new Type 
        public async Task AddTypeAsync(BDContext.Entity.Type1 entity)
        {
            await _type.AddTypeAsync(entity);
        }

        // Update information Type
        public async Task UpdateTypeAsync(BDContext.Entity.Type1 entity)
        {
            await _type.UpdateTypeAsync(entity);
        }

        // Delete Type by ID
        public async Task DeleteTypeAsync(int id)
        {
            await _type.DeleteTypeAsync(id);
        }
    }
}
