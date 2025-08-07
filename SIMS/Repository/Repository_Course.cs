using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Interface;

namespace SIMS.Repository
{
    public class Repository_Course : ICourse
    {
        private readonly SIMSDBContext _context;
        public Repository_Course(SIMSDBContext context)
        {
            _context = context;
        }
        public Task AddCourseAsync(Course entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCourseAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _context.CoursesDb
                .Include(c => c.Type)
                .ToListAsync();
        }

        public Task<Course?> GetCourseByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCourseAsync(Course entity)
        {
            throw new NotImplementedException();
        }
    }
}
