using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SIMS.BDContext;
using SIMS.BDContext.Entity;
using SIMS.Models;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class CourseController : Controller
    {
        private readonly Service_Course _courseService;
        private readonly SIMSDBContext sIMSDBContext;

        public CourseController(Service_Course courseService, SIMSDBContext dbContext)
        {
            _courseService = courseService;
            sIMSDBContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            ViewBag.Types = await sIMSDBContext.TypesDb.ToListAsync();
            return View(courses);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedAt = DateTime.Now;
                model.UpdatedAt = DateTime.Now;

                sIMSDBContext.CoursesDb.Add(model);
                await sIMSDBContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Types = await sIMSDBContext.TypesDb.ToListAsync();
            var CourseList = await sIMSDBContext.CoursesDb.Include(c => c.Type).ToListAsync();
            return View("Index", CourseList);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Course model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _courseService.UpdateCourseAsync(model);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Course model)
        {
            await _courseService.DeleteCourseAsync(model.CourseID);
            return RedirectToAction("Index");
        }
    }
}
