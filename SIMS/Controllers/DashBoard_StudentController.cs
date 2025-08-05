using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers
{
    public class DashBoard_StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
