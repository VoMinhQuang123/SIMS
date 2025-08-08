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
        public async Task AddCourseAsync(Course entity)
        {
            _context.CoursesDb.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _context.CoursesDb.FirstOrDefaultAsync(s => s.CourseID == id);

            if (course != null)
            {
                _context.CoursesDb.Remove(course);
                await _context.SaveChangesAsync();
            }
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

        public async Task UpdateCourseAsync(Course entity)
        {
            var existingCourse = await _context.CoursesDb.FindAsync(entity.CourseID);

            if (existingCourse != null)
            {
                existingCourse.NameCourse = entity.NameCourse;
                existingCourse.DescriptionCourse = entity.DescriptionCourse; 
                existingCourse.TypeID = entity.TypeID;
                await _context.SaveChangesAsync();
            }
        }
    }
}
