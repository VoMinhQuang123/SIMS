using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers
{
    public class Dashboard_AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
