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

    public class LoginController : Controller
    {
        private readonly ApplicationContext dbContext;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public LoginController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
           
        }

    
       
         public async Task<IActionResult> Login(string email, string password)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var login = await _userService.Login(email, password);
                var role = await _roleService.GetRoleByUserId(login.Data.Id);
                if (login.Success == false)
                {
                    return Content("Email or Password does not exist ");
                }
                  else if (login.Success == true && role == null)
                {
                    return RedirectToRoute(new { controller = "Customer", action = "Index", id = $"{login.Data.Id}" });
                }
                else if (login.Success == true && role.Success == true)
                {
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
                    //var role = await _roleService.GetRoleByUserId(login.Data.Id);
                    if (role.Data.Name == "Admin")
                    {
                        return RedirectToRoute(new { controller = "Admin", action = "Index", id = $"{login.Data.Id}" });
                    }
                }
              

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
