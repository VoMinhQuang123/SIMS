using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface ISemester
    {
        Task<List<Semester>> GetAllSemesteresAsync();
        Task<Semester?> GetSemesterByIDAsync(int id);
        Task AddSemesterAsync(Semester entity);
        Task UpdateSemesterAsync(Semester entity);
        Task DeleteSemesterAsync(int id);
    }
}
