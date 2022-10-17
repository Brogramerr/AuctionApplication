using AuctionApplication.DTOs;
using AuctionApplication.Models;
using AuctionApplication.Implementations.Services;
using AuctionApplication.Implementations.Repositories;
using AuctionApplication.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using AuctionApplication.Implementation.Services;
using AuctionApplication.Interface.Services;
using AuctionApplication.Interface.Repositories;

namespace AuctionApplication.Controllers
{
       
     
    public class StaffLoginController : Controller
    {
        private readonly ApplicationContext dbContext;
      
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public StaffLoginController(IUserService userService, IRoleService roleService)
        {
            
            _userService = userService;
           _roleService = roleService;
        }
        public async Task<IActionResult> LoginStaff(string email, string password)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var login = await _userService.Login(email, password);
                var role = await _roleService.GetRoleByUserId(login.Data.Id);
                
                if (login == null)
                {
                    return Content("Email or Password does not exist ");
                }
               
                var claims = new List<Claim>
                {
                    
                    new Claim (ClaimTypes.NameIdentifier, login.Data.Email),
                    new Claim (ClaimTypes.NameIdentifier, login.Data.Password)

                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
              await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Index", "Admin");
            }
            return View();

        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("StaffLogin");
        }



    }
}
