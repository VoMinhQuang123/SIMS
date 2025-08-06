using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Type : IType
    {
        public Task AddTypeAsync(BDContext.Entity.Type entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTypeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<BDContext.Entity.Type>> GetAllTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BDContext.Entity.Type?> GetTypeByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTypeAsync(BDContext.Entity.Type entity)
        {
            throw new NotImplementedException();
        }
    }
}
