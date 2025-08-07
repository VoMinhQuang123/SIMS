using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface ITeacher
    {
        Task<List<Teacher>> GetAllTeacheresAsync();
        Task<Teacher?> GetTeacherByIDAsync(int id);
        Task AddTeacherAsync(Teacher entity);
        Task UpdateTeacherAsync(Teacher entity);
        Task DeleteTeacherAsync(int id);
    }
}
