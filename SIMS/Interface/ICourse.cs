using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface ICourse
    {
        Task<List<Course>> GetAllCoursesAsync();
        Task<Course?> GetCourseByIDAsync(int id);
        Task AddCourseAsync(Course entity);
        Task UpdateCourseAsync(Course entity);
        Task DeleteCourseAsync(int id);
    }
}
