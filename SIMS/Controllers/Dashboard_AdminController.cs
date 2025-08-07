using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SIMS.Interface;
using SIMS.Models;
using SIMS.Service;

namespace SIMS.Controllers
{
    public class Dashboard_AdminController : Controller
    {
        private readonly Service_Admin _adminService;

        public Dashboard_AdminController(Service_Admin adminService)
        {
           _adminService = adminService;
        }

        public async Task<IActionResult> IndexAdmin()
        {
            var admins = await _adminService.GetAllAdminsAsync();

            var viewModel = admins.Select(a => new AdminViewModel
            {
                AdminID = a.AdminID,
                Name = a.Name,
                Email = a.Email,
                Role = a.Role ?? "Admin",
                CreatedAt = a.CreatedAt ?? DateTime.Now,
                UserID = a.UserID
            }).ToList();

            return View(viewModel); 
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
