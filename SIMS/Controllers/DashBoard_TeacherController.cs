using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers
{
    public class DashBoard_TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
