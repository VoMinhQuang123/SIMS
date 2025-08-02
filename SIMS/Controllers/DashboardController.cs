using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
