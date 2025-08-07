using Microsoft.AspNetCore.Mvc;

namespace SIMS.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
