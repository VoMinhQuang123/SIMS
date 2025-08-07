using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Service
{
    public class Service_Semester
    {
        // Inheriting interfaces
        private readonly ISemester _semester;

        // Create constructor
        public Service_Semester(ISemester semester)
        {
            _semester = semester;
        }

        // Get all Semesters
        public async Task<List<Semester>> GetAllSemestersAsync()
        {
            return await _semester!.GetAllSemesteresAsync();
        }

        // Get information Semester by ID
        public async Task<Semester?> GetSemesterByIDAsync(int id)
        {
            return await _semester.GetSemesterByIDAsync(id);
        }

        // Add new Semester
        public async Task AddSemesterAsync(Semester entity)
        {
            await _semester.AddSemesterAsync(entity);
        }

        // Update information semester
        public async Task UpdateSemesterAsync(Semester entity)
        {
            await _semester.UpdateSemesterAsync(entity);
        }

        // Delete semester by ID
        public async Task DeleteSemesterAsync(int id)
        {
            await _semester.DeleteSemesterAsync(id);
        }
    }
}
