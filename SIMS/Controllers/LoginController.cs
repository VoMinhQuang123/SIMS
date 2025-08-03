using Microsoft.AspNetCore.Mvc;
using SIMS.Models;

namespace SIMS.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // khong co loi 
                string email = model.Email.Trim();
                string password = model.Password.Trim();
                //return Ok(email+password);// check login _xem co loi khong 
                if (email.Equals("nguyentuan@gmail.com") && password.Equals("12345"))
                {
                    // dang nhap thanh cong - di vao trang dashboard
                    return RedirectToAction("Index", "Dashboard");


                }
                else
                {
                    // login khong thanh cong 
                    ViewData["MessageLogin"] = "Account Invalid , please try again!";
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Index", "Login");
        }
    }
}
