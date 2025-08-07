using Microsoft.AspNetCore.Mvc;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class TeacherController : Controller
    {
        private readonly Service_Teacher service_Teacher;
        public TeacherController(Service_Teacher service_Teacher)
        {
            this.service_Teacher = service_Teacher;
        }
        public async Task<IActionResult> IndexAsync()
        {

            var Teacher = await service_Teacher.GetAllTeachersAsync();
            return View(Teacher);
        }
        public IActionResult Create()
        {

            return View();
        }
    }
}
