using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Student : IStudent
    {
        public Task AddStudentAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student?> GetStudentByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateStudentAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
