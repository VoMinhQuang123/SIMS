using Microsoft.AspNetCore.Mvc;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class SemesterController : Controller
    {
        private readonly Service_Semester _serviceSemester;
        public SemesterController(Service_Semester serviceSemester)
        {
            _serviceSemester = serviceSemester;
        }
        public async Task<IActionResult> IndexAsync()
        {

            var Semester = await _serviceSemester.GetAllSemestersAsync();
            return View(Semester);
        }
        public IActionResult Create()
        {

            return View();
        }
    }
}
