using SIMS.BDContext.Entity;

namespace SIMS.Interface
{
    public interface IStudent
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIDAsync(int id);
        Task AddStudentAsync(Student entity);
        Task UpdateStudentAsync(Student entity);
        Task DeleteStudentAsync(int id);
    }
}
