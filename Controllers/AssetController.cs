using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using System.Diagnostics;

namespace AuctionApplication.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService; 
        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        public async Task<IActionResult> ChangeAssetPrice(int id, decimal price)
        {
            if(HttpContext.Request.Method == "POST")
            {
                var asset = await _assetService.ChangeAssetPriceAsync(id,price);
                if(asset.Success == true)
                {
                    return Content(asset.Message);
                }
            }
            return View(await _assetService.GetAssetsById(id));
        }

        public async Task<IActionResult> CreateAsset(CreateAssetRequestModel model)
        {
             if(HttpContext.Request.Method == "POST")
            {
                var asset = await _assetService.CreateAssetAsync(model);
                if(asset.Success == true)
                {
                    return Content(asset.Message);
                }
            }
            return View();
        }

        public async Task<IActionResult> ChangeAssetStatus(int id)
        {
            if(HttpContext.Request.Method == "POST")
            {
                var asset = await _assetService.ChangeAssetStatusToAuctioned(id);
                if(asset.Success == true)
                {
                    return Content(asset.Message);
                }
            }
            return View(await _assetService.ChangeAssetStatusToAuctioned(id));
        }
    }
}