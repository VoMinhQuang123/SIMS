using Microsoft.AspNetCore.Mvc;
using SIMS.Service;

namespace SIMS.Controllers
{

    public class DashBoard_StudentController : Controller
    {
        private readonly Service_Student _serviceStudent;
        public DashBoard_StudentController(Service_Student serviceStudent)
        {
            _serviceStudent = serviceStudent;
        }
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return View();
            }
            var student = await _serviceStudent.GetStudentByIDAsync(id.Value);
            HttpContext.Session.SetInt32("ClassID", student?.ClassID ?? 0);
            HttpContext.Session.SetInt32("UserID", id.Value);
            return View();
        }
        public async Task<IActionResult> Information(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var student = await _serviceStudent.GetStudentByIDAsync(id.Value);
            if (student == null)

                return NotFound();

            return View(student);
        }

    }
}
