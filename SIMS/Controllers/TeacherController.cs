using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
