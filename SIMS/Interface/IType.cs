using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface IType
    {
        Task<List<BDContext.Entity.Type1>> GetAllTypesAsync();
        Task<BDContext.Entity.Type1?> GetTypeByIDAsync(int id);
        Task AddTypeAsync(BDContext.Entity.Type1 entity);
        Task UpdateTypeAsync(BDContext.Entity.Type1 entity);
        Task DeleteTypeAsync(int id);
    }
}
