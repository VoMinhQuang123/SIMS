using Microsoft.AspNetCore.Mvc;
using SIMS.Models;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class CourseController : Controller
    {
        private readonly Service_Course _courseService;

        public CourseController(Service_Course courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return View(courses);
        }
    }
}
