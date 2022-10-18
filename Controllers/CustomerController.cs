using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionApplication.Context;
using AuctionApplication.Implementation.Services;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Customer()
        {
            return View();
        }

        
    }
}