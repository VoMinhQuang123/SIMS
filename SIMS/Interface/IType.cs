using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface IType
    {
        Task<List<BDContext.Entity.Type>> GetAllTypesAsync();
        Task<BDContext.Entity.Type?> GetTypeByIDAsync(int id);
        Task AddTypeAsync(BDContext.Entity.Type entity);
        Task UpdateTypeAsync(BDContext.Entity.Type entity);
        Task DeleteTypeAsync(int id);
    }
}
