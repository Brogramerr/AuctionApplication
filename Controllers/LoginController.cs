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
    public class LoginController : Controller
    {
        private readonly ApplicationContext dbContext;
      
        private readonly UserService userService;

        private readonly UserRepository userRepository;
        public LoginController(ApplicationContext context)
        {
            context = dbContext;
            userService = new UserService(userRepository);
           
        }

    
       
        public async Task<IActionResult> Login(string email, string password)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var login = await userService.Login(email, password);
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
                return RedirectToAction("Index", "Customer");
            }
            return View(Login);

        }
     
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }



    }
}
