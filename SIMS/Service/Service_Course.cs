using SIMS.BDContext.Entity;
using SIMS.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SIMS.Service
{
    public class Service_Course
    {
        // Inheriting interfaces
        private readonly ICourse _course;

        // Create constructor
        public Service_Course(ICourse course)
        {
            _course = course;
        }

        // Get all Courses
        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _course!.GetAllCoursesAsync();
        }

        // Get information Course by ID
        public async Task<Course?> GetCourseByIDAsync(int id)
        {
            return await _course.GetCourseByIDAsync(id);
        }

        // Add new Course 
        public async Task AddCourseAsync(Course entity)
        {
            await _course.AddCourseAsync(entity);
        }

        // Update information Course
        public async Task UpdateCourseAsync(Course entity)
        {
            await _course.UpdateCourseAsync(entity);
        }

        // Delete Course by ID
        public async Task DeleteCourseAsync(int id)
        {
            await _course.DeleteCourseAsync(id);
        }
    }
}
