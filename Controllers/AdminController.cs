using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Security.Claims;
using System.Web;


using System.Diagnostics;

namespace AuctionApplication.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        public AdminController(IAdminService adminService, IUserService userService)
        {
            _adminService = adminService;
            _userService = userService;
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
           public async Task<IActionResult> LoginAdmin(string email, string password)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var login = await _userService.Login(email, password);
                if (login == null)
                {
                    return Content("Email or Password does not exist ");
                }
             
                var claims = new List<Claim>
                {
                    new Claim (ClaimTypes.NameIdentifier, (login.Data.Id).ToString()),
                    new Claim (ClaimTypes.NameIdentifier, login.Data.Email),
                    new Claim (ClaimTypes.NameIdentifier, login.Data.Password),

                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToRoute(new { controller = "Customer", action = "GetCustomer", id = $"{login.Data.Id}" });
            }
            return View();

        }
     
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


    }
}