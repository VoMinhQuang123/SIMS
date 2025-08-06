using SIMS.BDContext.Entity;
using SIMS.Models;

namespace SIMS.Interface
{
    public interface IStudentRepository
    {
      
        Task<List<Student>> GetAllStudentsAsync();

        Task CreateStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(Student student);
        Task<bool> DeleteStudentAsync(int studentId);
        Task<Student?> GetStudentByIdAsync(int id);

    }
}
