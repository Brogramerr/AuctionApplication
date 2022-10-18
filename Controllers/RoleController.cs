using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AuctionApplication.Controllers
{
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<IActionResult> CreateRole(CreateRoleRequestmodel model)
        {
            if(HttpContext.Request.Method == "POST")
            {
                var role = await _roleService.AddRoleAsync(model);
                if(role.Success == true)
                {
                    return Content(role.Message);
                }
                return Content(role.Message);
            }
            return View();
        }

        public async Task<IActionResult> UpdateRole(UpdateUserRoleRequestModel model)
        {
            if(HttpContext.Request.Method == "POST")
            {
                var role = await _roleService.UpdateUserRole(model);
                if(role.Success == true)
                {
                    return Content(role.Message);
                }
                return Content(role.Message);
            }
            return View();
        }

        public async Task<IActionResult> ViewAllRoles()
        {
            var roles = await _roleService.GetAllRoleAsync();
            return View(roles);
        }
    }
}