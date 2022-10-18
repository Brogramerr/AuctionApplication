using AuctionApplication.DTOs;
using AuctionApplication.Models;
using AuctionApplication.Implementations.Services;
using AuctionApplication.Implementations.Repositories;


using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web;

using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using AuctionApplication.Implementation.Services;
using AuctionApplication.Interface.Services;
using AuctionApplication.DTOs.RequestModels;

namespace AuctionApplication.Controllers
{
    public class BiddingController : Controller
    {
        
        private readonly IBiddingService _biddingService;
        public BiddingController(IBiddingService biddingService)
        {
            _biddingService = biddingService;
        }

        public async Task<IActionResult> CreateBidding(CreateBiddingRequestModels model)
        {
            if(HttpContext.Request.Method == "POST")
            {
                var bidding = await _biddingService.CreateBiddingAsync(model);
                if(bidding.Success == true)
                {
                    return Content(bidding.Message);
                }
                return Content(bidding.Message);
            }
            return View();
        }

         public async Task<IActionResult> IncreaseBiddingPrice(UpdateBiddingRequestModels updateBidding)
         {
             if(HttpContext.Request.Method == "POST")
             {
                 var price = await _biddingService.IncreaseBiddingPriceAsync(updateBidding);
                 if(price.Success == true)
                 {
                     return Content(price.Message);
                 }
                 return Content(price.Message);
          }
            return View();
        }

         public async Task<IActionResult> TerminateBidding(UpdateBiddingRequestModels request)
         {
             if(HttpContext.Request.Method == "POST")
             {
                 var bidding = await _biddingService.TerminateBiddingAsync(request.BiddingId);
                 if(bidding.Success == true)
                 {
                     return Content(bidding.Message);
                 }
                 return Content(bidding.Message);
          }
            return View();
        }

        public async Task<IActionResult> GetBiddingsByAssetId(int id)
         {
             
                 var bidding = await _biddingService.GetBiddingByAssetIdAsync(id);
                 if(bidding.Success == true)
                 {
                     return View(bidding);
                 }
                 return Content(bidding.Message);
        }

        public async Task<IActionResult> GetHighestBidder()
         {
             
                 var bidding = await _biddingService.GetHighestBidder();
                 if(bidding.Success == true)
                 {
                     return View(bidding);
                 }
                 return Content(bidding.Message);
        }
    }
}