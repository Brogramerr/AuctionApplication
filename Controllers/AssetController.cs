using AuctionApplication.DTOs.RequestModels;
using AuctionApplication.Interface.Repositories;
using AuctionApplication.Interface.Services;
using AuctionApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using System.Diagnostics;
using System.Security.Claims;

namespace AuctionApplication.Controllers
{
    public class AssetController : Controller
    {
        private readonly IAssetService _assetService; 
        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        public async Task<IActionResult> ChangeAssetPrice(int id, decimal Price)
        {
            if(HttpContext.Request.Method == "POST")
            {
                var asset = await _assetService.ChangeAssetPriceAsync(id,Price);
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
                var context = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value); 
                var asset = await _assetService.CreateAssetAsync(context,model);
                if(asset.Success == true)
                {
                    return Content(asset.Message);
                }
            }
            return View();
        }

       public async Task<IActionResult> Delete(int  id)
        {
            if (HttpContext.Request.Method == "POST")
            {
                var result = await _assetService.DeleteAssetAsync(id);
                if (result.Success == true)
                {
                    return Content(result.Message);
                }
            }
            return View();
        }
    }
}