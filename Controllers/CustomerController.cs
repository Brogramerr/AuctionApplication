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

namespace AuctionApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
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



    }
}