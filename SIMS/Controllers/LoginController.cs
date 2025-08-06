using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIMS.BDContext.Entity;
using SIMS.Models;
using SIMS.Service;
using System.Security.Claims;

namespace SIMS.Controllers
{
    public class LoginController : Controller
    {
        private readonly Login_Service loginService;

        public LoginController(Login_Service loginService)
        {
            this.loginService = loginService;
        }
        public Login_Service LoginService => loginService;
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "DashBroad");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                string username = model?.Username?.Trim() ?? string.Empty;
                string password = model?.Password?.Trim() ?? string.Empty;
                var user = await LoginService.LoginUserAsync(username, password);
                if (user == null)
                {
                    ViewData["MessageLogin"] = "Account is invalid";
                    return View(model);
                }

                string? role = user.Role;
                switch (role)
                {
                    case "Admin":
                        return RedirectToAction("Index", "Dashboard_Admin");

                    case "Teacher":
                        return RedirectToAction("Index", "Dashboard_Teacher");

                    case "Student":
                        return RedirectToAction("Index", "Dashboard_Student");

                    default:
                        ViewData["MessageLogin"] = "Role is invalid";
                        return View(model);
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            foreach (var item in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(item);
            }
            return RedirectToAction("Index", "Login");
        }
    }
}

//var claims = new List<Claim>
//                {
//                    new Claim(ClaimTypes.Name, user.Username),
//                    new Claim(ClaimTypes.Role, user.Role)

//                };
//var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
