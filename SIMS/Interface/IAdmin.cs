using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface IAdmin
    {
        Task<List<Admin>> GetAllAdminsAsync();
        Task<Admin?> GetAdminByIDAsync(int id);
        Task AddAdminAsync(Admin entity);
        Task UpdateAdminAsync(Admin entity);
        Task DeleteAdminAsync(int id);
    }
}
