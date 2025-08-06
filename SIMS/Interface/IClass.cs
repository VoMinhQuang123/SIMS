using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface IClass
    {
        Task<List<Class>> GetAllClassesAsync();
        Task<Class?> GetClassByIDAsync(int id);
        Task AddClassAsync(Class entity);
        Task UpdateClassAsync(Class entity);
        Task DeleteClassAsync(int id);
    }
}
