using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using System.Diagnostics;

namespace AuctionApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> CreateAdmin(CreateAdminRequestModel model)
        {
            if(HttpContext.Request.Method == "POST")
            {
                var admin = await _adminService.AddAdmin(model);
                if(admin.Success == true)
                {
                    return Content(admin.Message);
                }
                return Content(admin.Message);
            }
            return View();
        }
        public async Task<IActionResult> DeleteAdmin(int id)
        {
                var admin = await _adminService.DeleteAdmin(id);
                if(admin.Success == true)
                {
                    return Content(admin.Message);
                }
                return Content(admin.Message);
        }

        public async Task<IActionResult> Admins()
        {
            var admins = await _adminService.GetAllAdmin();
            return View(admins);
        }
    }
}