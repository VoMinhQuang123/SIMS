using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers
{
    public class SemesterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
