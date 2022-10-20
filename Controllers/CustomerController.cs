using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApplication.Context;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.DTOs.ResponseModels;
using AuctionApplication.Implementation.Services;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;


using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using System.Security.Claims;
using System.Web;

namespace AuctionApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;

        public CustomerController(ICustomerService customerService, IUserService userService)
        {
            _customerService = customerService;
            _userService = userService;
        }

        public async Task<IActionResult> Create(CreateCustomerRequestModel model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var customer = await _customerService.Register(model);
                if (customer.Success == true)
                {
                    return Content(customer.Message);
                }
                return Content(customer.Message);
            }
            return View();
        }

        public async Task<IActionResult> GetCustomer(int Id)
        {
            if (HttpContext.Request.Method == "GET")
            {
                var customer = await _customerService.GetById(Id);
                if (customer.Success == false)
                {
                    return Content(customer.Message);
                }
                return Content(customer.Message);

            }
            return View();
        }

        public async Task<IActionResult> Update(UpdateCustomerRequestModels model)
        {
            if(HttpContext.Request.Method == "POST")
            {
                var customer = await _customerService.UpdateCustomer(model);
                if(customer.Success == true)
                {
                    return Content(customer.Message);
                }
                return Content(customer.Message);
            }
            return View();
        }
          public async Task<IActionResult> Login(string email, string password)
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