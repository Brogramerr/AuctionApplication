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

namespace AuctionApplication.Controllers
{
       
     
    //    [RoutePrefix("test")]
    public class StaffLoginController : Controller
    {
        private readonly ApplicationContext dbContext;
      
        private readonly UserService userService;

        private readonly UserRepository userRepository;
        private readonly RoleRepository roleRepository;
        private readonly RoleService roleService;
        public StaffLoginController(ApplicationContext context)
        {
            
            userService = new UserService(userRepository);
            roleService = new RoleService(roleRepository, userRepository);
           
        }
        public async Task<IActionResult> LoginStaff(string email, string password)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var login = await userService.Login(email, password);
                var role = await roleService.GetRoleByUserId(login.Data.Id);
                
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
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Index", "Admin");
            }
            return View(LoginStaff);

        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("StaffLogin");
        }



    }
}
