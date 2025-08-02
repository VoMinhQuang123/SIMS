using Microsoft.AspNetCore.Mvc;
using SIMS.Models;

namespace SIMS.Controllers
{
    public class CourseController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                // Lưu dữ liệu ở đây nếu cần
                return RedirectToAction("Index"); // Điều hướng sau khi lưu thành công
            }

            return View(course);
        }
    }
}
