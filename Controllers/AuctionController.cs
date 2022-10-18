using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using AuctionApplication.Implementation.Services;
using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Interface.Services;

namespace AuctionApplication.Controllers
{
    public class AuctionController : Controller
    {
        private readonly ILogger<AuctionController> _logger;
        private readonly IAuctionService _auctionService;
        public AuctionController(ILogger<AuctionController> logger, IAuctionService auctionService)
        {
            _logger = logger;
            _auctionService = auctionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateAuction(CreateAuctionRequestModels model)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var response = await  _auctionService.CreateAuctionAsync(model);
                if (response != null)
                {
                    ViewBag.Info = TempData[$"{response.Message}"];
                return Index();
                }
                return Content("Model Error");
            }

            return Index();
        }
        public async Task<IActionResult> ChangeAuctionOpeningDate(int id, DateTime date)
        {
            if (HttpContext.Request.Method == "POST")
            {
               var response = await _auctionService.ChangeAuctionOpeningDateAsync(id, date);
               ViewBag.Info = TempData[$"{response.Message}"];
               return Index();
            }
            return StatusCode(404);
        }
        public async Task<IActionResult> ChangeAuctionDuration(int id, int days)
        {
            if (HttpContext.Request.Method == "POST")
            {
               var response =  await _auctionService.ChangeAuctionDurationAsync(id, days);
               ViewBag.Info = TempData[$"{response.Message}"];
               return Index();
            }
            return StatusCode(404);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}